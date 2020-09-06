namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public class CsvReport : BaseReport
    {
        public CsvReport(ReportType type, string path)
            : base(type, path) => Format = FileFormatType.Csv;
    }
}
