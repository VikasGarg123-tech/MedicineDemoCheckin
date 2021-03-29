using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineDemo.Businesslogic.Contracts;
using MedicineDemo.Businesslogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MedicineDemo.DataRepository;
using MedicineDemo.DataAccess;

namespace MedicineDemo
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200")
                                         .AllowAnyMethod()
                                         .AllowAnyHeader()
                                         );
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MedicineDemo", Version = "v1" });
            });

            services.AddSingleton<IMedicineBusinesslogic, MedicineBusinesslogic>();
            services.AddSingleton<BaseDataRepository, MedicineRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Medicine Demo Service");
            });
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.ContentType == null || context.Request.ContentType.Equals("text/plain", System.StringComparison.OrdinalIgnoreCase))
            //    {
            //        context.Request.ContentType = "application/json";
            //    }
            //    await next();
            //});
            app.UseCors("CorsPolicy");
            //app.UseMvc();


            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}