using Kelly.API.Utilities;
using Kelly.APIService.Interfaces;
using Kelly.ApplicationService.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Kelly.APIService
{
    public class APIService : IAPIService
    {
        private IOrderProcessorService _orderProcessorService;
        public APIService(IOrderProcessorService orderProcessorService)
        {
            _orderProcessorService = orderProcessorService;
        }
        public async Task<HttpStatusCode> PlaceOrder(OrderAPIServiceDto order)
        {
            return await _orderProcessorService.PlaceOrder(order.ToOrderApplicationServiceDto());            
        }
    }
}
