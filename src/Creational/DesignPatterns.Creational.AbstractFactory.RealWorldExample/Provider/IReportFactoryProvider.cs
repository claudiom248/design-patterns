using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Provider
{
    public interface IReportFactoryProvider
    {
        IReportFactory GetFactory(FileFormatType format);
    }
}
