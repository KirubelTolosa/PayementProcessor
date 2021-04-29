using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kelly.APIService.Interfaces
{
    public interface IAPIService
    {
        Task<HttpStatusCode> PlaceOrder(OrderAPIServiceDto order);        
    }
}
