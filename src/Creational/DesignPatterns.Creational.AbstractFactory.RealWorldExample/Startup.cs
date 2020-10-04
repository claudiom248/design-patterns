using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Provider;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using Wkhtmltopdf.NetCore;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddSingleton(Environment.ContentRootFileProvider);

            services.AddSingleton<IBookService, BookService>();
            services.AddScoped<IReportService, ReportService>();

            AddPdfGenerator(services);
            AddReportFactories(services);

            services.AddMvc(opt =>
            {
                opt.ModelBinderProviders.Insert(0, new ModelBinder.ReportFormatTypeModelBinderProvider());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void AddPdfGenerator(IServiceCollection services)
        {
            var wkhtmlRelativePath = Path.Combine(@"..\..\..\", Configuration.GetValue<string>("WkhtmltopdfFolder"));
            services.AddWkhtmltopdf(wkhtmlRelativePath);
        }

        private void AddReportFactories(IServiceCollection services)
        {
            var fileProvider = services.BuildServiceProvider().GetService<IFileProvider>();
            var templatesFolderPath = Configuration.GetValue<string>("ReportsTemplatesFolder");
            var stagingFolderPath = Configuration.GetValue<string>("ReportsStagingFolder");

            if (!fileProvider.GetFileInfo(stagingFolderPath).Exists)
            {
                Directory.CreateDirectory(fileProvider.GetFullPath(stagingFolderPath));
            }

            services.AddScoped<CsvConcreteReportFactory, CsvConcreteReportFactory>(serviceProvider => new CsvConcreteReportFactory(
                fileProvider,
                stagingFolderPath));

            services.AddScoped<PdfConcreteReportFactory, PdfConcreteReportFactory>(serviceProvider => new PdfConcreteReportFactory(
                fileProvider,
                serviceProvider.GetService<IGeneratePdf>(),
                templatesFolderPath,
                stagingFolderPath));

            services.AddScoped<IReportFactoryProvider, ContainerBasedReportFactoryProvider>();
        }
    }
}
