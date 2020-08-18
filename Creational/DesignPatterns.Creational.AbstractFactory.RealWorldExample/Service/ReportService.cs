using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;

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

        public IReport CreateBooksReport(FileFormatType format)
        {
            var books = _bookService.GetAll();
            return GetReportFactory(format).CreateBooksReport(books);
        }

        public IReportFactory GetReportFactory(FileFormatType format) 
            => _reportFactoryGenerator.GetFactory(format);
    }
}
