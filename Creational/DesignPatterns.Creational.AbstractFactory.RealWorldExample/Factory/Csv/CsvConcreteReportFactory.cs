using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
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
    internal class CsvConcreteReportFactory : IAbstractReportFactory
    {
        private readonly IFileProvider _fileProvider;
        private readonly string _stagingFolderPath;

        public CsvConcreteReportFactory(IFileProvider fileProvider, string stagingFolderPath)
        {
            _stagingFolderPath = stagingFolderPath;
            _fileProvider = fileProvider;

            if (!_fileProvider.GetFileInfo(stagingFolderPath).Exists)
            {
                Directory.CreateDirectory(_fileProvider.GetCombinedPath(stagingFolderPath));
            }
        }

        public IReport CreateBooksReport(IEnumerable<Book> books)
        {
            return new CsvReport()
            {
                Name = GenerateBooksReportName(),
                Path = CreateBooksReportFile(books)
            };
        }

        private string GenerateBooksReportName()
        {
            return $"AllBooks-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.csv";
        }

        private string CreateBooksReportFile(IEnumerable<Book> books)
        {
            var relativePath = GetTempFilePath();
            File.WriteAllText(_fileProvider.GetCombinedPath(relativePath), GetBooksReportCsv(books));
            return relativePath;
        }

        private string GetBooksReportCsv(IEnumerable<Book> books)
        {
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.Append(GetBooksReportHeader());
            AppendLinesToStringBuilder(GetBooksAsStrings(books), csvBuilder);

            return csvBuilder.ToString();
        }

        private string GetBooksReportHeader()
        {
            return "ISBN,Title,Price,Author,CopiesSold\n";
        }

        private string[] GetBooksAsStrings(IEnumerable<Book> books)
        {
            return books.Select(b => string.Join(",", b.Isbn, b.Title, b.Price, b.Author, b.CopiesSold)).ToArray();
        }

        private void AppendLinesToStringBuilder(IEnumerable<string> lines, StringBuilder stringBuilder)
        {
            foreach (string line in lines)
            {
                stringBuilder.Append($"{line}\n");
            }
        }

        private string GetTempFilePath()
        {
            return Path.Combine(_stagingFolderPath, $"{Guid.NewGuid()}.csv");
        }
    }
}
