using Kelly.ApplicationService.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService
{
    public class ShipmentService : IShipmentService
    {
        private readonly IConfiguration _configuration;
        public ShipmentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool ShipOrder(string productName, int amount)
        {
            var shippingDepartmentEmail = _configuration["ShippingEmail"];
            return true;
        }
    }
}
