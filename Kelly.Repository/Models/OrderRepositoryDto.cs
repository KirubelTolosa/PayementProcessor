using System;
using System.ComponentModel.DataAnnotations;

namespace Kelly.Repository
{
    public class OrderRepositoryDto
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public CreditCardInfoRepositoryDto CreditCardInfo { get; set; }
    }
    // The model is not designed for PCI Compliance. Thereare more secure ways of doing this.
    public class CreditCardInfoRepositoryDto
    {

        public CreditCardAttribute CreditCardNumber { get; set; }
        public string NameOnCard { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }
    }
}