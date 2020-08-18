using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Pages
{
    public class IndexModel : PageModel
    {
        private const string ContentType = "application/octet-stream";
        private readonly IBookService _bookService;
        private readonly IReportService _reportService;

        public IEnumerable<Book> Books { get; set; }

        public IndexModel(IBookService bookService, IReportService reportService)
        {
            _bookService = bookService;
            _reportService = reportService;
        }

        public IActionResult OnGet()
        {
            Books = _bookService.GetAll();
            return Page();
        }

        public IActionResult OnGetExportReport(FileFormatType format)
        {
            var report = _reportService.CreateBooksReport(format);
            return DownloadReport(report);
        }

        private IActionResult DownloadReport(IReport report) 
            => File(new FileStream(report.Path, FileMode.Open), ContentType, report.Name);
    }
}
