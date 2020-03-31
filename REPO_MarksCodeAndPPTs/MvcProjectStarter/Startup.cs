using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcProjectStarter.Data;
using MvcProjectStarter.Services;

namespace MvcProjectStarter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // here we register services to be injected as dependencies, e.g. into controllers
            //   or anything else that ASP.NET Core creates.
            //services.AddSingleton<IRequestCounter, RequestCounter>();
            // "if anyone needs an IRequestCounter, make a RequestCounter using the zero-param ctor."
            // "and if anyone else needs one afterwards, reuse the same instance forever (singleton lifetime)"

            // there are three lifetimes for services...
            // 1. transient (everyone who needs this service, gets a brand new one)
            // 2. scoped (reuse one instance in the context of each HTTP request)
            // 3. singleton (one instance for whole app forever)
            //services.AddScoped<IRequestCounter, RequestCounter>(); // won't work for this case, object is discarded
            //services.AddTransient<IRequestCounter, RequestCounter>(); // won't work for this case, object is discarded

            services.AddControllersWithViews();

            services.AddDbContext<MvcSongContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcSongContext")));
            // ^ this line registers the DbContext as a service, by default with the scoped lifetime
            // (means one DbContext instance per HTTP request)
            // it's pulling the connection string from the Configuration object,
            //    ... which is loaded form several sources
            //  https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration
            // for example: environment variables, appsettings.json files, user secrets (in Development env only)


            // user secrets is a convenient way to hide development configuration outside this solution's folder
            // (so it won't be tracked by git)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
