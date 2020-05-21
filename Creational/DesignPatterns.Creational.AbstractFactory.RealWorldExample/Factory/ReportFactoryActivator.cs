using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf;
using Microsoft.Extensions.FileProviders;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory
{
    public class ReportFactoryActivator : IReportFactoryActivator
    {
        private readonly IFileProvider _fileProvider;
        private readonly string _stagingFolderPath;

        public ReportFactoryActivator(IFileProvider fileProvider, string stagingFolderPath)
        {
            _fileProvider = fileProvider;
            _stagingFolderPath = stagingFolderPath;
        }

        public IAbstractReportFactory GetReportFactory(ExportFormatType format)
        {
            if (format == ExportFormatType.Csv)
            {
                return new CsvConcreteReportFactory(_fileProvider, _stagingFolderPath);
            }

            if (format == ExportFormatType.Pdf)
            {
                return new PdfConcreteReportFactory(_fileProvider, _stagingFolderPath);
            }

            throw new ArgumentException(nameof(format));
        }
    }
}
