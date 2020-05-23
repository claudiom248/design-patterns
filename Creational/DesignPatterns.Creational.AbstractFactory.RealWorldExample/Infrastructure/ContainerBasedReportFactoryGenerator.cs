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

        public ContainerBasedReportFactoryGenerator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public IAbstractReportFactory GetFactory(ReportFormatType format)
        {
            if (format == ReportFormatType.Csv)
            {
                return _serviceProvider.GetService<CsvConcreteReportFactory>();
            }

            return _serviceProvider.GetService<PdfConcreteReportFactory>();
        }
    }
}
