using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Utility;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using Wkhtmltopdf.NetCore;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf
{
    public class PdfConcreteReportFactory : IReportFactory
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
        }

        public IReport CreateBooksReport(IEnumerable<Book> books) 
            => new PdfReport(ReportType.AllBooks, BuildFile(books));

        private string BuildFile(IEnumerable<Book> books)
        {
            var reportRelativePath = Path.Combine(_stagingFolderPath, $"{Guid.NewGuid()}.pdf");
            File.WriteAllBytes(_fileProvider.GetFullPath(reportRelativePath), GetPdfByteArray(books));
            return _fileProvider.GetFullPath(reportRelativePath);
        }

        private byte[] GetPdfByteArray(IEnumerable<Book> books) => 
            _generatePdf.GetByteArray(GetBooksTemplateFilePath(), books).Result;

        private string GetBooksTemplateFilePath() =>
            Path.Combine(_templatesFolderPath, AllBooksTemplateFilePath);
    }
}
