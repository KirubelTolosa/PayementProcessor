using Kelly.ApplicationService.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<HttpStatusCode> PlaceOrder(OrderApplicationServiceDto order)
        {
            bool productAvailable = _inventoryService.CheckProductAvailabliltiy(order.ProductName, order.Amount);
            HttpStatusCode x;
            if (productAvailable)
            {
                decimal total = _inventoryService.GetProductPrice(order.ProductName) * order.Amount;
                var paymentSucceded = _paymentService.ChargeCard(order.CreditCardNumber, total);
                if (paymentSucceded)
                {
                    x = await _shipmentService.EmailShipmentOrder(order.ProductName, order.Amount);
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
