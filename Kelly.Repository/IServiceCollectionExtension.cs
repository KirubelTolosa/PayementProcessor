using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.Repository
{
    public static class IServiceCollectionExtension
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddRepositoryService(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services.AddTransient<IRepositoryService, RepositoryService>();
            return services;
        }
    }
}
