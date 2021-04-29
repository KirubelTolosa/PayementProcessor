using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Kelly.ApplicationService
{
    public class PaymentService : IPaymentService
    {
        private IConfiguration _configuration;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool ChargeCard(CreditCardInfoApplicationServiceDto creditCardInfo, double amount)
        {
            string paymentGatewayURL = _configuration.GetSection("PaymentGatewaySettings")["PaymentGatewayURL"];
            bool response = true;
            
            try
            {
                #region Call to external payment gateway. Mocked below with an internal call to "ChargePayment" method.
                /*
                JObject requestObject = new JObject();
                requestObject["amount"] = amount;
                requestObject["creditCardInfo"] = JObject.FromObject(new
                {
                    creditCardNumber = creditCardInfo.CreditCardNumber,
                    nameOnCard = creditCardInfo.NameOnCard,
                    expirationDate = creditCardInfo.ExpirationDate,
                    cvv = creditCardInfo.CVV
                });
                var json = JsonConvert.SerializeObject(requestObject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("/*"));                
                    response = client.PostAsync(paymentGatewayURL, data).Result;
                response.EnsureSuccessStatusCode();
                }
                */
                #endregion
                response = ChargePayement(creditCardInfo, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Message: {0}", ex.Message);
                throw ex;
            }
            
            return response;
        }
        public bool ChargePayement(CreditCardInfoApplicationServiceDto creditCardInfo, double amount)
        {
            // The account balance is hardcoded to simplify the implementation
            double accountBalance = 100;
            string isVisa = "^4[0-9]{12}(?:[0-9]{3})?$";

            //Simple scenarios for testing purposes              
            if (!System.Text.RegularExpressions.Regex.IsMatch(creditCardInfo.CreditCardNumber, isVisa)) //Invalid CreditCard Info. Only accepting VISA
            {
                return false;
            }
            else if (amount > accountBalance) //Not enough balance 
            {
                return false;
            }
            return true;
        }
    }
}
