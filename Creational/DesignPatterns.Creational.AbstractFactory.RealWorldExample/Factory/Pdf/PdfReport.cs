using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf
{
    public class PdfReport : IReport
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public DateTime CreationDate { get; set; }

        public string Path { get; set; }

        public PdfReport()
        {
            Extension = ".pdf";
            CreationDate = DateTime.Now;
        }
    }
}
