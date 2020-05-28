using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public class ReportType
    {
        public static ReportType AllBooks => new ReportType { ReportId = "AllBooks", ReportName = "AllBooks" };

        public string ReportId { get; set; }

        public string ReportName { get; set; }

        public string GetFileName(ReportFormatType format)
        {
            string extension = format == ReportFormatType.Csv ? "csv" : "pdf";
            return $"{ReportName}-{DateTime.Now.ToString("yyyyMMddHHmmss")}.{extension}";
        }
    }
}
