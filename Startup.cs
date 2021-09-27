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
using first.Models;
using Microsoft.EntityFrameworkCore;

namespace first
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DBContext.DBContext>(options => options.UseNpgsql(connection));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }

        private static void FirstPage(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("FirstPage");
            });
        }
        private static void SecondPage(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("SecondPage");
            });
        }


    }
}
