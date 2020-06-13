using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public abstract class BaseReport : IReport
    {
        public string Name => Type.GetFileName(Format);

        public ReportType Type { get; set; }

        public ReportFormatType Format { get; set; }

        public DateTime CreationDate { get; set; }

        public string Path { get; set; }

        protected BaseReport(ReportType type) => Type = type;
    }
}
