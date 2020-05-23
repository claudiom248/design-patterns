using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System.Collections;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory
{
    public interface IReportFactoryActivator
    {
        IAbstractReportFactory GetReportFactory(ReportFormatType format);
    }
}
