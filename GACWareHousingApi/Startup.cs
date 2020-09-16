using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GACWareHousingApi.DataProviders;
using GACWareHousingApi.DBContext;
using GACWareHousingApi.Helpers;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace GACWareHousingApi
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
            services.AddDbContext<GACWareHouseContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:GACWarehousingDB"]));

            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GAC Warehousing API", Version = "v1" });
            });

            services.AddScoped<IDataRepository<Customer>, CustomerProvider>();
            services.AddScoped<IDataRepository<Manfacturer>, ManfacturerProvider>();
            services.AddScoped<IDataRepository<Product>, ProductProvider>();
            services.AddScoped<IDataRepository<SalesOrder>, SalesOrderProvider>();
            services.AddScoped<IDataRepository<SalesOrderDetail>, SalesOrderDetailProvider>();

            services.AddControllers();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GAC Warehousing API V1");
            });
        }
    }
}
