using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.APIService.Interfaces
{
    public interface IAPIService
    {
        bool ProcessOrder(OrderAPIServiceDto order);        
    }
}
