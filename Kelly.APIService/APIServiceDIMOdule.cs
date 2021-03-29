using Autofac;
using Kelly.ApplicationService;
using Kelly.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.APIService
{
    public static class APIServiceDIMOdule
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<IOrderProcessorService>().As<IOrderProcessorService>();
            ApplicationServiceDIModule.RegisterServices(builder);
        }
    }
}
