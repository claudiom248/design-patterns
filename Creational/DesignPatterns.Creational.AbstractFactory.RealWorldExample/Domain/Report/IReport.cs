using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report
{
    public interface IReport
    {
        public string Name { get; }

        public ReportType Type { get; }

        public FileFormatType Format { get; }

        public DateTime CreationDate { get; }

        public string Path { get; }
    }
}
