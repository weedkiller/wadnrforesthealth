﻿using System;
using System.IO;
using System.Reflection;

namespace LtInfo.Common
{
    public struct LtInfoVersionInfo
    {
        private readonly DateTime _dateCompiled;
        private readonly Version _version;

        public LtInfoVersionInfo(Assembly assemblyToDeriveInfoFrom)
            : this()
        {
            _version = assemblyToDeriveInfoFrom.GetName().Version;
            var localAssemblyPathString = new Uri(assemblyToDeriveInfoFrom.CodeBase).LocalPath;
            _dateCompiled = File.GetLastWriteTime(localAssemblyPathString);
        }

        public Version ApplicationVersion
        {
            get { return _version; }
        }

        public DateTime DateCompiled
        {
            get { return _dateCompiled; }
        }
    }
}