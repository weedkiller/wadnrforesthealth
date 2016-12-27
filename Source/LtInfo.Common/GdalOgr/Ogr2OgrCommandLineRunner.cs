﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.GdalOgr
{
    /// <summary>
    /// Wrapper class for calling ogr2ogr.exe for the purpose of importing data from a File Geodatabase (.gdb) using the OpenFileGDB drivers in GDAL 1.11 and above
    /// </summary>
    public class Ogr2OgrCommandLineRunner
    {
        public const int DefaultCoordinateSystemId = 4326;
        public const int DefaultTimeOut = 110000;
        public const string OgrGeoJsonTableName = "OGRGeoJSON";

        private readonly FileInfo _ogr2OgrExecutable;
        private readonly int _coordinateSystemId;
        private readonly double _totalMilliseconds;
        private readonly DirectoryInfo _gdalDataPath;

        public Ogr2OgrCommandLineRunner(string pathToOgr2OgrExecutable, int coordinateSystemId, double totalMilliseconds)
        {
            _totalMilliseconds = totalMilliseconds;
            _ogr2OgrExecutable = new FileInfo(pathToOgr2OgrExecutable);
            _coordinateSystemId = coordinateSystemId;
            Check.RequireFileExists(_ogr2OgrExecutable, "Can't find ogr2ogr program in expected path. Is it installed?");
            Check.RequireNotNull(_ogr2OgrExecutable.Directory, string.Format("ogr2ogr must be a full path including directory but was \"{0}\"", _ogr2OgrExecutable.FullName));
            // ReSharper disable once PossibleNullReferenceException
            _gdalDataPath = new DirectoryInfo(Path.Combine(_ogr2OgrExecutable.Directory.FullName, "gdal-data"));
            Check.RequireDirectoryExists(_gdalDataPath.FullName, "Can't find gdal-data directory needed for import with ogr2ogr");
        }

        /// <summary>
        /// Import GDB to SQL using GDAL Ogr2Ogr command line tool
        /// </summary>
        public void ImportFileGdbToMsSql(FileInfo inputGdbFile, string sourceLayerName, string destinationTableName, List<string> columnNameList, string connectionString)
        {
            Check.Require(inputGdbFile.FullName.ToLower().EndsWith(".gdb.zip"), string.Format("Input filename for GDB input must end with .gdb.zip. Filename passed is {0}", inputGdbFile.FullName));
            Check.RequireFileExists(inputGdbFile, "Can't find input File GDB for import with ogr2ogr");

            var databaseConnectionString = string.Format("MSSQL:{0}", connectionString);
            var commandLineArguments = BuildCommandLineArgumentsForFileGdbToMsSql(inputGdbFile, _gdalDataPath, databaseConnectionString, sourceLayerName, destinationTableName, columnNameList, _coordinateSystemId);
            ExecuteOgr2OgrCommand(commandLineArguments);
        }

        public string ImportFileGdbToGeoJson(FileInfo inputGdbFile, string sourceLayerName)
        {            
            Check.Require(inputGdbFile.FullName.ToLower().EndsWith(".gdb.zip"), string.Format("Input filename for GDB input must end with .gdb.zip. Filename passed is {0}", inputGdbFile.FullName));
            Check.RequireFileExists(inputGdbFile, "Can't find input File GDB for import with ogr2ogr");

            var commandLineArguments = BuildCommandLineArgumentsForFileGdbToGeoJson(inputGdbFile, _gdalDataPath, sourceLayerName, _coordinateSystemId);
            var processUtilityResult = ExecuteOgr2OgrCommand(commandLineArguments);
            return processUtilityResult.StdOut;
        }

        public void ImportGeoJsonToMsSql(string geoJson, string connectionString, string destinationTableName, string sourceColumnName, string destinationColumnName, string extraColumns)
        {
            var databaseConnectionString = string.Format("MSSQL:{0}", connectionString);
            using (var geoJsonFile = DisposableTempFile.MakeDisposableTempFileEndingIn(".json"))
            {
                File.WriteAllText(geoJsonFile.FileInfo.FullName, geoJson);
                var commandLineArguments = BuildCommandLineArgumentsForGeoJsonToMsSql(geoJsonFile.FileInfo,
                    sourceColumnName, destinationTableName, destinationColumnName, _gdalDataPath, databaseConnectionString, _coordinateSystemId, extraColumns);
                ExecuteOgr2OgrCommand(commandLineArguments);
            }
        }

        /// <summary>
        /// Import GDB to SQL using GDAL Ogr2Ogr command line tool
        /// </summary>
        public void ImportArcGisQueryToMsSql(string arcGisQuery, string destinationTableName, string sourceColumnName, string destinationColumnName, string connectionString)
        {
            var databaseConnectionString = string.Format("MSSQL:{0}", connectionString);
            var commandLineArguments = BuildCommandLineArgumentsForArgGisQueryToMsSql(arcGisQuery, _gdalDataPath, databaseConnectionString, destinationTableName, sourceColumnName, destinationColumnName, _coordinateSystemId);
            ExecuteOgr2OgrCommand(commandLineArguments);
        }

        private ProcessUtilityResult ExecuteOgr2OgrCommand(List<string> commandLineArguments)
        {
            var processUtilityResult = ProcessUtility.ShellAndWaitImpl(_ogr2OgrExecutable.DirectoryName, _ogr2OgrExecutable.FullName, commandLineArguments, true, Convert.ToInt32(_totalMilliseconds));
            if (processUtilityResult.ReturnCode != 0)
            {
                var argumentsAsString = String.Join(" ", commandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
                var fullProcessAndArguments = String.Format("{0} {1}", ProcessUtility.EncodeArgumentForCommandLine(_ogr2OgrExecutable.FullName), argumentsAsString);
                var errorMessage =
                    string.Format("Process \"{0}\" returned with exit code {1}, expected exit code 0.\r\n\r\nStdErr and StdOut:\r\n{2}\r\n\r\nProcess Command Line:\r\n{3}\r\n\r\nProcess Working Directory: {4}",
                        _ogr2OgrExecutable.Name,
                        processUtilityResult,
                        processUtilityResult.StdOutAndStdErr,
                        fullProcessAndArguments,
                        _ogr2OgrExecutable.DirectoryName);
                throw new Ogr2OgrCommandLineException(errorMessage);
            }
            return processUtilityResult;
        }

        /// <summary>
        /// Produces the command line arguments for ogr2ogr.exe to run the File Geodatabase import.
        /// <example>"C:\Program Files\GDAL\ogr2ogr.exe" -progress -append --config GDAL_DATA "C:\Program Files\GDAL\gdal-data" -t_srs "EPSG:4326" -f MSSQLSpatial "MSSQL:server=(local);database=Scratch;trusted_connection=yes" "C:\temp\GdalScratch\Sub_Actions_20131219.gdb" "Sub_Actions_Polygon_20131219" -nln MyTable</example>
        /// </summary>
        internal static List<string> BuildCommandLineArgumentsForFileGdbToMsSql(FileInfo inputGdbFile, DirectoryInfo gdalDataDirectoryInfo, string databaseConnectionString, string sourceLayerName, string targetTableName, List<string> columnNameList, int coordinateSystemId)
        {
            var reservedFields = new[] { "Ogr_Fid", "Ogr_Geometry" };
            var filteredColumnNameList = columnNameList.Where(x => reservedFields.All(y => !String.Equals(x, y, StringComparison.InvariantCultureIgnoreCase))).ToList();
            const string ogr2OgrColumnListSeparator = ",";
            Check.Require(filteredColumnNameList.All(x => !x.Contains(ogr2OgrColumnListSeparator)), string.Format("Found column names with separator character \"{0}\", can't continue. Columns:{1}", ogr2OgrColumnListSeparator, String.Join("\r\n",filteredColumnNameList)));
            Check.Require(filteredColumnNameList.All(x => !Regex.IsMatch(x, @"\s")), string.Format("Found column names with whitespace in them, can't continue. Columns:{0}", String.Join("\r\n",filteredColumnNameList)));

            var selectStatement = string.Format("select {0} from {1}", String.Join(ogr2OgrColumnListSeparator + " ", filteredColumnNameList), sourceLayerName);
            var commandLineArguments =  new List<string>
            {
                "-append",
                "-sql",
                selectStatement,
                "--config",
                "GDAL_DATA",
                gdalDataDirectoryInfo.FullName,
                "-t_srs",
                GetMapProjection(coordinateSystemId),
                "-f",
                "MSSQLSpatial",
                databaseConnectionString,
                inputGdbFile.FullName,
                "-nln",
                targetTableName
            };

            return commandLineArguments;
        }

        /// <summary>
        /// Produces the command line arguments for ogr2ogr.exe to run the File Geodatabase import.
        /// <example>"C:\Program Files\GDAL\ogr2ogr.exe" -progress -append --config GDAL_DATA "C:\Program Files\GDAL\gdal-data" -t_srs "EPSG:4326" -f MSSQLSpatial "MSSQL:server=(local);database=Scratch;trusted_connection=yes" "C:\temp\GdalScratch\Sub_Actions_20131219.gdb" "Sub_Actions_Polygon_20131219" -nln MyTable</example>
        /// </summary>
        internal static List<string> BuildCommandLineArgumentsForArgGisQueryToMsSql(string arcGisQuery, DirectoryInfo gdalDataDirectoryInfo, string databaseConnectionString, string targetTableName, string sourceColumnName, string destinationColumnName, int coordinateSystemId)
        {
            var commandLineArguments =  new List<string>
            {
                "-append",
                "-sql",
                string.Format("SELECT {0} AS {1} FROM {2}", sourceColumnName, destinationColumnName, OgrGeoJsonTableName),
                "--config",
                "GDAL_DATA",
                gdalDataDirectoryInfo.FullName,
                "-t_srs",
                GetMapProjection(coordinateSystemId),
                "-f",
                "MSSQLSpatial",
                databaseConnectionString,
                string.Format("\"{0}\"", arcGisQuery),
                "-nln",
                targetTableName
            };

            return commandLineArguments;
        }

        internal static List<string> BuildCommandLineArgumentsForGeoJsonToMsSql(FileInfo sourceGeoJsonFile, string sourceColumnName, string destinationTableName, string destinationColumnName, DirectoryInfo gdalDataDirectoryInfo, string databaseConnectionString, int coordinateSystemId, string extraColumns)
        {
            //c:\SVN\sitkatech\trunk\Corral\Build>"C:\Program Files\GDAL\ogr2ogr.exe" -preserve_fid --config GDAL_DATA "C:\\Program Files\\GDAL\\gdal-data" -t_srs EPSG:4326 -f MSSQLSpatial "MSSQL:server=localhost;database=tempdb;trusted_connection=yes" "C:\temp\geojson.json" -nln "TestTable"            

            var commandLineArguments = new List<string>
            {
                "-append",
                "-sql",
                string.Format("SELECT {0} AS {1}{2} FROM {3}", sourceColumnName, destinationColumnName, extraColumns, OgrGeoJsonTableName),
                "--config",
                "GDAL_DATA",
                gdalDataDirectoryInfo.FullName,
                "-t_srs",
                GetMapProjection(coordinateSystemId),
                "-explodecollections",
                "-f",
                "MSSQLSpatial",
                databaseConnectionString,
                sourceGeoJsonFile.FullName,
                "-nln",
                destinationTableName
            };

            return commandLineArguments;
        }

        /// <summary>
        /// Produces the command line arguments for ogr2ogr.exe to run the File Geodatabase import.
        /// <example>"C:\Program Files\GDAL\ogr2ogr.exe" -preserve_fid --config GDAL_DATA "C:\\Program Files\\GDAL\\gdal-data" -t_srs EPSG:4326 -f GeoJSON /dev/stdout "C:\\svn\\sitkatech\\trunk\\Corral\\Source\\Corral.Web\\Models\\GdalOgr\\SampleFileGeodatabase.gdb.zip" "somelayername"</example>
        /// </summary>
        internal static List<string> BuildCommandLineArgumentsForFileGdbToGeoJson(FileInfo inputGdbFile, DirectoryInfo gdalDataDirectoryInfo, string sourceLayerName, int coordinateSystemId)
        {
            var commandLineArguments =  new List<string>
            {
                "--config",
                "GDAL_DATA",
                gdalDataDirectoryInfo.FullName,
                "-t_srs",
                GetMapProjection(coordinateSystemId),
                "-explodecollections",
                "-f",
                "GeoJSON",
                "/dev/stdout",
                inputGdbFile.FullName,
                string.Format("\"{0}\"", sourceLayerName)
            };

            return commandLineArguments;
        }

        public static string GetMapProjection(int coordinateSystemId)
        {
            return string.Format("EPSG:{0}", coordinateSystemId);
        }
    }
}