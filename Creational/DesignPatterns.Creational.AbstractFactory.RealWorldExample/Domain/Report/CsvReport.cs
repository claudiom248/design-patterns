namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public class CsvReport : BaseReport
    {
        public CsvReport(ReportType type)
            : base(type)
        {
            Format = ReportFormatType.Csv;
        }
    }
}
