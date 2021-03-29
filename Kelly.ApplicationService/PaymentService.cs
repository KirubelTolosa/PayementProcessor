using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService
{
    public class PaymentService : IPaymentService
    {
        private IConfiguration _configuration;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            string paymentGatewayUrl = _configuration["PaymentGatewayURL"];
            return true;
        }
    }
}
