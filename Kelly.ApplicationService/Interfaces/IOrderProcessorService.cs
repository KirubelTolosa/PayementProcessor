using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kelly.ApplicationService.Interfaces
{
    public interface IOrderProcessorService
    {
        Task<HttpStatusCode> PlaceOrder(OrderApplicationServiceDto order);
    }
}
