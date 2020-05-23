using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Infrastructure;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
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

            var wkhtmlRelativePath = Path.Combine(@"..\..\..\", Configuration.GetValue<string>("WkhtmltopdfFolder"));
            services.AddWkhtmltopdf(wkhtmlRelativePath);

            services.AddSingleton(Environment.ContentRootFileProvider);
            AddReportFactories(services);
            services.AddSingleton<IBookService, BookService>();
            services.AddScoped<IReportService, ReportService>();
        }

        public void AddReportFactories(IServiceCollection services)
        {
            var reportsTemplatesFolderPath = Configuration.GetValue<string>("ReportsTemplatesFolder");
            var reportsStagingFolderPath = Configuration.GetValue<string>("ReportsStagingFolder");

            services.AddScoped<CsvConcreteReportFactory, CsvConcreteReportFactory>(serviceProvider =>
            {
                return new CsvConcreteReportFactory(
                    serviceProvider.GetService<IFileProvider>(),
                    reportsStagingFolderPath);
            });

            services.AddScoped<PdfConcreteReportFactory, PdfConcreteReportFactory>(serviceProvider =>
            {
                return new PdfConcreteReportFactory(
                    serviceProvider.GetService<IFileProvider>(),
                    serviceProvider.GetService<IGeneratePdf>(),
                    reportsTemplatesFolderPath,
                    reportsStagingFolderPath);
            });

            services.AddScoped<ReportFactoryActivator>(serviceProvider => reportFormatType =>
            {
                if (reportFormatType == Domain.ReportFormatType.Csv)
                {
                    return serviceProvider.GetService<CsvConcreteReportFactory>();
                }

                if (reportFormatType == Domain.ReportFormatType.Pdf)
                {
                    return serviceProvider.GetService<PdfConcreteReportFactory>();
                }

                throw new ArgumentException(nameof(reportFormatType));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
