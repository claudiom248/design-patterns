using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv
{
    public class CsvReport : IReport
    {
        public string Name { get; set; }

        public ReportFormatType Format { get; set; }

        public DateTime CreationDate { get; set; }

        public string Path { get; set; }

        public CsvReport() => Format = ReportFormatType.Csv;
    }
}
