using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract
{
    public interface IReport
    {
        public string Name { get; set; }

        public ReportFormatType Format { get; set; }

        public DateTime CreationDate { get; set; }

        public string Path { get; set; }
    }
}
