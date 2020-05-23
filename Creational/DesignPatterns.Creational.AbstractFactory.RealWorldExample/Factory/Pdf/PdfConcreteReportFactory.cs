using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Utility;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using Wkhtmltopdf.NetCore;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf
{
    public class PdfConcreteReportFactory : IAbstractReportFactory
    {
        private const string AllBooksTemplateFilePath = "AllBooks.cshtml";

        private readonly IFileProvider _fileProvider;
        private readonly IGeneratePdf _generatePdf;
        private readonly string _templatesFolderPath;
        private readonly string _stagingFolderPath;

        public PdfConcreteReportFactory(IFileProvider fileProvider, IGeneratePdf generatePdf, string templatesFolderPath, string stagingFolderPath)
        {
            _fileProvider = fileProvider;
            _generatePdf = generatePdf;
            _stagingFolderPath = stagingFolderPath;
            _templatesFolderPath = templatesFolderPath;

            if (!_fileProvider.GetFileInfo(stagingFolderPath).Exists)
            {
                Directory.CreateDirectory(_fileProvider.GetCombinedPath(stagingFolderPath));
            }
        }

        public IReport CreateBooksReport(IEnumerable<Book> books)
        {
            return new PdfReport()
            {
                Name = ReportType.AllBooks.GetFileName(ReportFormatType.Pdf),
                Path = CreateBooksReportFile(books)
            };
        }

        private string CreateBooksReportFile(IEnumerable<Book> books)
        {
            byte[] pdfByteArray = _generatePdf.GetByteArray(GetBooksTemplateFile(), books).Result;
            var relativePath = GetTempFilePath();
            File.WriteAllBytes(_fileProvider.GetCombinedPath(relativePath), pdfByteArray);
            return relativePath;
        }

        private string GetBooksTemplateFile()
        {
            return Path.Combine(_templatesFolderPath, AllBooksTemplateFilePath);
        }

        private string GetTempFilePath()
        {
            return Path.Combine(_stagingFolderPath, $"{Guid.NewGuid()}.pdf");
        }
    }
}
