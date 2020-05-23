using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Infrastructure;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public class ReportService : IReportService
    {
        private readonly IBookService _bookService;
        private readonly ReportFactoryActivator _reportFactoryActivator;

        public ReportService(
            IBookService bookService,
            ReportFactoryActivator reportFactoryActivator)
        {
            _bookService = bookService;
            _reportFactoryActivator = reportFactoryActivator;
        }

        public IReport CreateBooksReport(ReportFormatType format)
        {
            IEnumerable<Book> books = _bookService.GetAll();
            IAbstractReportFactory factory = _reportFactoryActivator(format);
            return factory.CreateBooksReport(books); ;
        }
    }
}
