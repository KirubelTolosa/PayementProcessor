using Kelly.ApplicationService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IOrderProcessorService, OrderProcessorService>();
            return services;
        }
    }
}
