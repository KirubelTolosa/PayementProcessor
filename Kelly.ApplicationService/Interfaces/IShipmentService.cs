using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService.Interfaces
{
    public interface IShipmentService
    {
        //Assuming user address is not required.
        bool ShipOrder(string productName, int amount);
    }
}
