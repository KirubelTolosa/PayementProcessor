using Autofac;
using Kelly.APIService.Interfaces;
using Kelly.ApplicationService;
using Kelly.ApplicationService.Interfaces;
using Kelly.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelly.API
{
    public class APIDIModule :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            base.Load(builder);
            builder.RegisterType<Kelly.APIService.APIService>().As<IAPIService>();
            builder.RegisterType<OrderProcessorService>().As<IOrderProcessorService>();
            builder.RegisterType<RepositoryService>().As<IRepositoryService>();
        }
    }
}
