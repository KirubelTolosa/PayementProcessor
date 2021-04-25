using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService.Interfaces
{
    public interface IOrderProcessorService
    {
        bool PlaceOrder(OrderApplicationServiceDto order);
    }
}
