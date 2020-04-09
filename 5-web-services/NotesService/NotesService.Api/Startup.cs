using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotesService.Api.Repositories;

namespace NotesService.Api
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
            services.AddSingleton<INoteRepository, NoteRepository>();

            //services.AddControllers(options =>
            //{
            //    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
            //    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            //});
            services.AddControllers(options =>
            {
                //options.Filters.Add(new ProducesAttribute("application/xml")); // remember filters can be global too
            })
                .AddXmlSerializerFormatters(); // teach asp.net how to both serialize and deserialize
                                               //using XmlSerializer object. (application / xml)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // with APIs, as opposed to MVC, we use attribute routing in our controller classes,
            // rather than global/conventional routing here in the Startup class.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
