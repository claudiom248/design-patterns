namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public class PdfReport : BaseReport
    {
        public PdfReport(ReportType type)
            : base(type) => Format = ReportFormatType.Pdf;
    }
}
