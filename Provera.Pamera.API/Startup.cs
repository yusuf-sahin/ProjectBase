using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Provera.Pamera.Business.Abstract;
using Provera.Pamera.Business.Concrete;
using Provera.Pamera.Data.Abstract;
using Provera.Pamera.Data.Concrete;

namespace Provera.Pamera.API
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

            PameraContext.ConnectionString = Configuration.GetConnectionString("DefaultConnection").ToString();
           // services.AddDbContext<PameraContext>(
            //options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), 
            //                                    b => b.MigrationsAssembly("Provera.Pamera.API")));

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            services.AddCors();
            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x => x.AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowAnyOrigin()
                               .AllowCredentials()
                                );

            //app.UseAuthentication();
            // app.UseHttpsRedirection();
            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            // app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
