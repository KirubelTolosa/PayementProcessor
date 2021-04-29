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
                CreditCardInfo = order.CreditCardInfo.ToCreditCardInfoAPIServiceDto()
            };
        }
        public static CreditCardInfoAPIServiceDto ToCreditCardInfoAPIServiceDto(this CreditCardInfoAPIDto creditCardInfo)
        {
            return new CreditCardInfoAPIServiceDto
            {
                CreditCardNumber = creditCardInfo.CreditCardNumber,
                NameOnCard = creditCardInfo.NameOnCard,
                ExpirationDate = creditCardInfo.ExpirationDate,
                CVV = creditCardInfo.CVV
            };
        }
    }
}
