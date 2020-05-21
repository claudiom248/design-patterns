using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddSingleton<IReportService, ReportService>();
            AddReportFactoryActivator(services);
        }

        public void AddReportFactoryActivator(IServiceCollection services)
        {
            string reportsStagingFolder = Configuration.GetValue<string>("ReportsStagingFolder");
            ReportFactoryActivator reportFactoryActivator = new ReportFactoryActivator(Environment.ContentRootFileProvider, reportsStagingFolder);
            services.AddSingleton<IReportFactoryActivator>(reportFactoryActivator);

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
