using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Utility;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv
{
    internal class CsvConcreteReportFactory : IReportFactory
    {
        private readonly IFileProvider _fileProvider;
        private readonly string _stagingFolderPath;

        public CsvConcreteReportFactory(IFileProvider fileProvider, string stagingFolderPath)
        {
            _stagingFolderPath = stagingFolderPath;
            _fileProvider = fileProvider;
        }

        public IReport CreateBooksReport(IEnumerable<Book> books) =>
            new CsvReport(ReportType.AllBooks)
            {
                Path = CreateBooksReportFile(books)
            };

        private string CreateBooksReportFile(IEnumerable<Book> books)
        {
            var reportPath = Path.Combine(_stagingFolderPath, $"{Guid.NewGuid()}.csv");
            File.WriteAllText(_fileProvider.GetCombinedPath(reportPath), GetBooksReportCsv(books));
            return reportPath;
        }

        private string GetBooksReportCsv(IEnumerable<Book> books)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.Append(GetBooksReportHeader());
            AppendLinesToStringBuilder(GetBooksAsStrings(books), csvBuilder);
            return csvBuilder.ToString();
        }

        private string GetBooksReportHeader() => "ISBN,Title,Price,Author,CopiesSold\n";

        private string[] GetBooksAsStrings(IEnumerable<Book> books) =>
            books.Select(b => string.Join(",", b.Isbn, b.Title, b.Price, b.Author, b.CopiesSold)).ToArray();

        private void AppendLinesToStringBuilder(IEnumerable<string> lines, StringBuilder stringBuilder)
        {
            foreach (var line in lines)
            {
                stringBuilder.Append($"{line}\n");
            }
        }
    }
}
