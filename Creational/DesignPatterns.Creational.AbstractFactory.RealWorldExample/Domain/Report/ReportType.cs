using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public class ReportType
    {
        public static ReportType AllBooks => new ReportType { ReportId = "AllBooks", ReportName = "AllBooks" };

        public string ReportId { get; set; }

        public string ReportName { get; set; }

        public string GetFileName(FileFormatType format) => $"{ReportName}-{DateTime.Now:yyyyMMddHHmmss}.{format.Extension}";
    }
}
