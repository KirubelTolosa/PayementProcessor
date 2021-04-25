using SendGrid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kelly.ApplicationService.Interfaces
{
    public interface IShipmentService
    {
        //Assuming user address is not required.
        Task<Response> EmailShipmentOrder(string productName, int amount);
    }
}
