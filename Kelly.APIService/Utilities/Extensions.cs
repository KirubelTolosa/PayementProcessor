using Kelly.APIService;
using Kelly.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelly.API.Utilities
{
    public static class Extensions
    {
        public static OrderApplicationServiceDto ToOrderApplicationServiceDto(this OrderAPIServiceDto order)
        {
            return new OrderApplicationServiceDto
            {
                ProductName = order.ProductName,
                Amount = order.Amount,
                CreditCardInfo = order.CreditCardInfo.ToCreditCardInfoAPIServiceDto()
            };
        }
        public static CreditCardInfoApplicationServiceDto ToCreditCardInfoAPIServiceDto(this CreditCardInfoAPIServiceDto creditCardInfo)
        {
            return new CreditCardInfoApplicationServiceDto
            {
                CreditCardNumber = creditCardInfo.CreditCardNumber,
                NameOnCard = creditCardInfo.NameOnCard,
                ExpirationDate = creditCardInfo.ExpirationDate,
                CVV = creditCardInfo.CVV
            };
        }
    }
}
