using Kelly.API.Utilities;
using Kelly.APIService.Interfaces;
using Kelly.ApplicationService.Interfaces;
using System;

namespace Kelly.APIService
{
    public class APIService : IAPIService
    {
        private IOrderProcessorService _orderProcessorService;
        public APIService(IOrderProcessorService orderProcessorService)
        {
            _orderProcessorService = orderProcessorService;
        }
        public bool PlaceOrder(OrderAPIServiceDto order)
        {
            return _orderProcessorService.PlaceOrder(order.ToOrderApplicationServiceDto());            
        }
    }
}
