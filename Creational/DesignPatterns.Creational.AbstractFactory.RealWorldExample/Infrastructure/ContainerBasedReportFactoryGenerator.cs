using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Infrastructure
{
    public class ContainerBasedReportFactoryGenerator : IReportFactoryGenerator
    {
        private readonly IServiceProvider _serviceProvider;

        public ContainerBasedReportFactoryGenerator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAbstractReportFactory GetFactory(ReportFormatType format) =>
            format switch
            {
                ReportFormatType.Csv => _serviceProvider.GetService<CsvConcreteReportFactory>(),
                ReportFormatType.Pdf => _serviceProvider.GetService<PdfConcreteReportFactory>(),
                _ => throw new NotSupportedException($"Invalid format type {format}")
            };
    }
}
