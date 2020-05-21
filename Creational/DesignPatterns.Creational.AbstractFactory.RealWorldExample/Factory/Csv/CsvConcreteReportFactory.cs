using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv
{
    internal class CsvConcreteReportFactory : IAbstractReportFactory
    {
        private string _stagingFolderPath;

        public CsvConcreteReportFactory(string stagingFolderPath)
        {
            _stagingFolderPath = stagingFolderPath;

            if (!Directory.Exists(_stagingFolderPath))
            {
                Directory.CreateDirectory(stagingFolderPath);
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

        public string GenerateBooksReportName()
        {
            return $"AllBooks-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.csv";
        }

        private string CreateBooksReportFile(IEnumerable<Book> books)
        {
            string filePath = GetTempFilePath();
            File.WriteAllText(filePath, GetBooksReportCsv(books));
            return filePath;
        }

        private string GetBooksReportCsv(IEnumerable<Book> books)
        {
            var csvBuilder = new StringBuilder();
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
            foreach (var line in lines)
            {
                stringBuilder.Append($"{line}\n");
            }
        }

        private string GetTempFilePath()
        {
            string fileName = $"{Guid.NewGuid()}.csv";
            return Path.Combine(_stagingFolderPath, fileName);
        }
    }
}
