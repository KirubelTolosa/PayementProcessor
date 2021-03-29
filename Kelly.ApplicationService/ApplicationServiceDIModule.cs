using Autofac;
using Kelly.ApplicationService.Interfaces;
using Kelly.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService
{
    public static class ApplicationServiceDIModule
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ShipmentService>().As<IShipmentService>();
            builder.RegisterType<PaymentService>().As<IPaymentService>();
            builder.RegisterType<InventoryService>().As<InventoryService>();
            RepositoryDIModule.RegisterServices(builder);
        }
    }
}
