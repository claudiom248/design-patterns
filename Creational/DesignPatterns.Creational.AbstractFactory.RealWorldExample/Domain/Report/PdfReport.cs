using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf
{
    public class PdfReport : IReport
    {
        public string Name { get; set; }

        public ReportFormatType Format { get; set; }

        public DateTime CreationDate { get; set; }

        public string Path { get; set; }

        public PdfReport() => Format = ReportFormatType.Pdf;
    }
}
