using Kelly.APIService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.APIService
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAPIService(this IServiceCollection services)
        {
            services.AddTransient<IAPIService, APIService>();
            return services;
        }
    }
}
