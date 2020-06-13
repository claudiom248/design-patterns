using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Pages
{
    public class IndexModel : PageModel
    {
        private const string ContentType = "application/octet-stream";
        private readonly IBookService _bookService;
        private readonly IReportService _reportService;
        private readonly IFileProvider _fileProvider;

        public IEnumerable<Book> Books { get; set; }

        public IndexModel(IBookService bookService, IReportService reportService, IFileProvider fileProvider)
        {
            _bookService = bookService;
            _reportService = reportService;
            _fileProvider = fileProvider;
        }

        public void OnGet() => Books = _bookService.GetAll();

        public ActionResult OnGetExportReport(ReportFormatType format)
        {
            var report = _reportService.CreateBooksReport(format);
            var file = _fileProvider.GetFileInfo(report.Path);
            return File(file.CreateReadStream(), ContentType, report.Name);
        }
    }
}
