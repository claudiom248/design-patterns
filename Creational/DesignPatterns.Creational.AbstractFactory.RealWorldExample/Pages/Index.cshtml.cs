using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Pages
{
    public class IndexModel : PageModel
    {
        private const string ContentType = "application/octet-stream";
        private readonly IReportService _reportService;
        private readonly IFileProvider _fileProvider;

        public IndexModel(IReportService reportService, IFileProvider fileProvider)
        {
            _reportService = reportService;
            _fileProvider = fileProvider;
        }

        public ActionResult OnGet()
        {
            IReport report = _reportService.CreateBooksReport(ReportFormatType.Csv);
            var generatedReportFile = _fileProvider.GetFileInfo(report.Path);
            return File(generatedReportFile.CreateReadStream(), ContentType, report.Name);
        }
    }
}
