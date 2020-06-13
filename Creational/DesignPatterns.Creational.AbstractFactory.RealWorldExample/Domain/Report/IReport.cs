using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public interface IReport
    {
        public string Name { get; }

        public ReportType Type { get; set; }

        public ReportFormatType Format { get; set; }

        public DateTime CreationDate { get; set; }

        public string Path { get; set; }
    }
}
