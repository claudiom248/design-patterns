using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract
{
    public interface IReportFactoryGenerator
    {
        IReportFactory GetFactory(FileFormatType format);
    }
}
