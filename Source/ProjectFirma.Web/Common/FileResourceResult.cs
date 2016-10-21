﻿using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    /// <summary>
    /// A generic FileResource result.
    /// Can be used bare, but designed to be used inherited (WordResult, ExcelResult, PdfResult, etc.)
    /// </summary>
    public class FileResourceResult : ActionResult
    {
        protected FileResourceMimeType FileResourceMimeType { get; private set; }
        protected MemoryStream MemoryStream { get; private set; }

        /// <summary> 
        /// Gets a value for file name. 
        /// </summary> 
        public string Filename { get; private set; }

        /// <summary> 
        /// Action Result: File Result constructor for creating a downloadable file result
        /// </summary> 
        /// <param name="fileName">Filename here</param> 
        /// <param name="memoryStream"></param>
        /// <param name="fileResourceMimeType"></param> 
        public FileResourceResult(string fileName, MemoryStream memoryStream, FileResourceMimeType fileResourceMimeType)
        {
            ConstructorImpl(fileName, memoryStream, fileResourceMimeType);
        }

        public FileResourceResult(string fileName, byte[] fileBytes, FileResourceMimeType fileResourceMimeType)
        {
            var memoryStream = new MemoryStream(fileBytes);
            ConstructorImpl(fileName, memoryStream, fileResourceMimeType);
        }

        protected void ConstructorImpl(string fileName, MemoryStream memoryStream, FileResourceMimeType fileResourceMimeType)
        {
            FileResourceMimeType = fileResourceMimeType;
            MemoryStream = memoryStream;
            Filename = fileName;
        }

        /// <summary> 
        /// Execute the Result. 
        /// </summary> 
        /// <param name="context">Controller context.</param> 
        public override void ExecuteResult(ControllerContext context)
        {
            WriteStream(MemoryStream, Filename, FileResourceMimeType);
        }

        /// <summary> 
        /// Writes the memory stream to the browser. 
        /// </summary>
        /// <param name="memoryStream">Memory stream.</param>
        /// <param name="fileName">File name.</param>
        /// <param name="fileResourceMimeType"></param>
        private static void WriteStream(MemoryStream memoryStream, string fileName, FileResourceMimeType fileResourceMimeType)
        {
            var context = HttpContext.Current;
            context.Response.Clear();

            context.Response.AddHeader("Content-Type", fileResourceMimeType.FileResourceMimeTypeName);

            context.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=\"{0}\"", fileName));
            memoryStream.WriteTo(context.Response.OutputStream);
            memoryStream.Close();
            context.Response.End();
        }
    }
}