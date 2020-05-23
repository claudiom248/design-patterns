using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Infrastructure
{
    public delegate IAbstractReportFactory ReportFactoryActivator(ReportFormatType reportFormatType);
}
