using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv
{
    public class CsvReport : IReport
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public DateTime CreationDate { get; set; }

        public string Path { get; set; }

        public CsvReport()
        {
            Extension = ".csv";
            CreationDate = DateTime.Now;
        }
    }
}
