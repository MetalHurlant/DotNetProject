using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISEN.DotNet.Library.Repositories.Interfaces;
using ISEN.DotNet.Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ISEN.DotNet.Library.Repositories.Implementation;

namespace ISEN.DotNet.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //using ISEN.DotNet.Web.Data;
            //using Microsoft.EntityFrameworkCore;
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));

            // Add framework services.
            services.AddMvc();

            // Ajouter ses propres services
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IVoyageRepository, VoyageRepository>();    
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();

            services.AddScoped<SeedData>();

            //services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSession();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // SeedData
            var seedService = app.ApplicationServices.GetService<SeedData>();
            seedService.DropCreateDatabase();
            seedService.AddPersons();
            seedService.AddVoyages();
            seedService.AddBookings();
        }
    }
}
