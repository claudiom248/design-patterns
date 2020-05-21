using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf
{
    internal class PdfConcreteReportFactory : IAbstractReportFactory
    {
        public IReport CreateBooksReport(IEnumerable<Book> books)
        {
            throw new System.NotImplementedException();
        }
    }
}
