using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract
{
    public interface IReportFactoryGenerator
    {
        IAbstractReportFactory GetFactory(ReportFormatType format);
    }
}
