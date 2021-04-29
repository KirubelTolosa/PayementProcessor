using System;
using System.ComponentModel.DataAnnotations;

namespace Kelly.APIService
{
    public class OrderAPIDto
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public CreditCardInfoAPIDto CreditCardInfo { get; set; }
    }
    // The model is not designed for PCI Compliance. Thereare more secure ways of doing this.
    public class CreditCardInfoAPIDto
    {
        //[CreditCard]
        public string CreditCardNumber { get; set; }
        public string NameOnCard { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }
    }
}