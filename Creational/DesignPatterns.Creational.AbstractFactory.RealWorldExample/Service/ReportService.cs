using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public class ReportService : IReportService
    {
        private readonly IBookService _bookService;
        private readonly IReportFactoryGenerator _reportFactoryGenerator;

        public ReportService(
            IBookService bookService,
            IReportFactoryGenerator reportFactoryActivator)
        {
            _bookService = bookService;
            _reportFactoryGenerator = reportFactoryActivator;
        }

        public IReport CreateBooksReport(ReportFormatType format)
        {
            IEnumerable<Book> books = _bookService.GetAll();
            IAbstractReportFactory factory = _reportFactoryGenerator.GetFactory(format);
            return factory.CreateBooksReport(books);
        }
    }
}
