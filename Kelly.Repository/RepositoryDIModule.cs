using Autofac;
using Kelly.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.Repository
{
    public static class RepositoryDIModule
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryService>().As<IRepositoryService>();
        }
    }
}
