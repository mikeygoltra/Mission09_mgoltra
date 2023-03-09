using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission09_mgoltra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mgoltra
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
                object p = options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);
            });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Corresponds to wwwroot folder
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                //endpoints are ran in order!!

                endpoints.MapControllerRoute("categorypage",
                    "{bookCategory}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1});

                endpoints.MapControllerRoute("type", "{projectType}", new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

            });
        }
    }
}
