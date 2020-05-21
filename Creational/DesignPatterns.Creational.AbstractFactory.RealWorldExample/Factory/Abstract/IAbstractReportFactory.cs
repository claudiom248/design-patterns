using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract
{
    internal interface IAbstractReportFactory
    {
        public IReport CreateBooksReport(IEnumerable<Book> books);
    }
}