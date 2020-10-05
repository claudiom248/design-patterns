namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public class PdfReport : BaseReport
    {
        public PdfReport(ReportType type, string path)
            : base(type, path) => Format = FileFormatType.Pdf;
    }
}