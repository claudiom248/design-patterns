using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Infrastructure
{
    public interface IReportFactoryGenerator
    {
        IAbstractReportFactory GetFactory(ReportFormatType format);
    }
}
