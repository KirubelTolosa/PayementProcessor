using Kelly.APIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelly.API.Utilities
{
    public static class Extensions
    {
        public static OrderAPIServiceDto ToOrderAPIServiceDto(this OrderAPIDto order)
        {
            return new OrderAPIServiceDto
            {
                ProductName = order.ProductName,
                Amount = order.Amount,
                CreditCardNumber = order.CreditCardNumber
            };
        }
    }
}
