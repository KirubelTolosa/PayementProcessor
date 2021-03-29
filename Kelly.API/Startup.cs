using Autofac;
using Kelly.API;
using Kelly.API.Swagger;
using Kelly.APIService;
using Kelly.APIService.Interfaces;
using Kelly.ApplicationService;
using Kelly.ApplicationService.Interfaces;
using Kelly.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelly
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
            services.AddControllers();
            services.AddSwaggerDocumentation();

            services.AddScoped<IAPIService, Kelly.APIService.APIService>();
            services.AddScoped<IOrderProcessorService, OrderProcessorService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IShipmentService, ShipmentService>();      
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IRepositoryService, RepositoryService>();
            services
                .AddControllersWithViews();
            services.AddSingleton<IConfiguration>(Configuration);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerDocumentation();
            app.UseDeveloperExceptionPage();

        }

    }
}
