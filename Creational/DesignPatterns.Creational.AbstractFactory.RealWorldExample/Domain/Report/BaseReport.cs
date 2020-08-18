using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public abstract class BaseReport : IReport
    {
        public string Name => Type.GetFileName(Format);

        public ReportType Type { get; protected set; }

        public FileFormatType Format { get; protected set; }

        public DateTime CreationDate { get; protected set; }

        public string Path { get; protected set; }

        protected BaseReport(ReportType type, string path)
        {
            Type = type;
            Path = path;
        }
    }
}
