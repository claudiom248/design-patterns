using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Provider
{
    public class ContainerBasedReportFactoryProvider : IReportFactoryProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public ContainerBasedReportFactoryProvider(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public IReportFactory GetFactory(FileFormatType format)
        {
            if (format == FileFormatType.Csv)
            {
                return _serviceProvider.GetService<CsvConcreteReportFactory>();
            }

            if (format == FileFormatType.Pdf)
            {
                return _serviceProvider.GetService<PdfConcreteReportFactory>();
            }

            throw new NotSupportedException($"Invalid format type {format}");
        }
    }
}