using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public interface IReportService
    {
        IReport CreateBooksReport(ReportFormatType format);
    }
}