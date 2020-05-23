using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Infrastructure
{
    public interface IReportFactoryGenerator
    {
        IAbstractReportFactory GetFactory(Domain.ReportFormatType format);
    }
}
