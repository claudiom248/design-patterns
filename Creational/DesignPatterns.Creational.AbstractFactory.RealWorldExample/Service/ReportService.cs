using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public class ReportService : IReportService
    {
        private readonly IBookService _bookService;
        private readonly IReportFactoryActivator _reportFactoryActivator;

        public ReportService(
            IBookService bookService,
            IReportFactoryActivator reportFactoryActivator)
        {
            _bookService = bookService;
            _reportFactoryActivator = reportFactoryActivator;
        }

        public IReport CreateBooksReport(ReportFormatType format)
        {
            IEnumerable<Book> books = _bookService.GetAll();
            IAbstractReportFactory factory = _reportFactoryActivator.GetReportFactory(format);
            return factory.CreateBooksReport(books); ;
        }
    }
}
