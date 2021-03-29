using Kelly.ApplicationService.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService
{
    public class OrderProcessorService : IOrderProcessorService
    {
        private readonly IInventoryService _inventoryService;
        private readonly IPaymentService _paymentService;
        private readonly IShipmentService _shipmentService;

        public OrderProcessorService(
            IInventoryService inventoryService,
            IPaymentService paymentService,
            IShipmentService shipmentService, IConfiguration configuration)
        {
            _inventoryService = inventoryService;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
        }
        public bool ProcessOrder(OrderApplicationServiceDto order)
        {
            bool productAvailable = _inventoryService.CheckProductAvailabliltiy(order.ProductName, order.Amount);
            if (productAvailable)
            {
                decimal total = _inventoryService.CheckProductPrice(order.ProductName) * order.Amount;
                var paymentSucceded = _paymentService.ChargePayment(order.CreditCardNumber, total);
                if (paymentSucceded)
                {
                    _shipmentService.ShipOrder(order.ProductName, order.Amount);
                }
                
            }
            else
            {
                return false;
            }
            return true;
        }

        
    }
}
