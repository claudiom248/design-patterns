using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Utility;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf
{
    public class PdfConcreteReportFactory : IAbstractReportFactory
    {
        private readonly IFileProvider _fileProvider;
        private readonly string _stagingFolderPath;

        public PdfConcreteReportFactory(IFileProvider fileProvider, string stagingFolderPath)
        {
            _fileProvider = fileProvider;
            _stagingFolderPath = stagingFolderPath;

            if (!_fileProvider.GetFileInfo(stagingFolderPath).Exists)
            {
                Directory.CreateDirectory(_fileProvider.GetCombinedPath(stagingFolderPath));
            }
        }

        public IReport CreateBooksReport(IEnumerable<Book> books)
        {
            throw new System.NotImplementedException();
        }
    }
}
