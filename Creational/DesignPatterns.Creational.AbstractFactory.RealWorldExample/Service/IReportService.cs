using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public interface IReportService
    {
        IReport CreateBooksReport(ExportFormatType format);
    }
}