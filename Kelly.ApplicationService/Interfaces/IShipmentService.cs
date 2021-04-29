using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kelly.ApplicationService.Interfaces
{
    public interface IShipmentService
    {
        //Assuming user address is not required.
        Task<HttpStatusCode> EmailShipmentOrder(string productName, int amount, bool test = false);
    }
}
