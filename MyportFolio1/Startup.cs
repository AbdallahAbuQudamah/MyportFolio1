using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.Models;
using Microsoft.EntityFrameworkCore;
using MyportFolio1.BL;

namespace MyportFolio1
{
    public class Startup
    {
        IConfiguration Config;
        public Startup(IConfiguration Abd)
        {
            Config= Abd;
        }
     
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddDbContext<MyportfolioDBContext>(options => options.UseSqlServer(Config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IIslider, CLSslider>();
            services.AddScoped<IIaboutme,CLSaboutme>();
            services.AddScoped<IISerf, CLSmyserf>();
            services.AddScoped<IICart, CLSmycard>();
            services.AddScoped<IIraseme, CLSresme>();
            services.AddScoped<IIcontc, CLScontctme>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name:"areas",
                   pattern:"{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
