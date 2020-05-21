using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv
{
    internal class CsvConcreteReportFactory : IAbstractReportFactory
    {
        public IReport CreateBooksReport(IEnumerable<Book> books)
        {
            throw new NotImplementedException();
        }
    }
}
