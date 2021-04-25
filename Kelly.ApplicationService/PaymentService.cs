using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public bool ChargeCard(string creditCardNumber, decimal amount)
        {
            string paymentGatewayURL = _configuration["PaymentGatewayURL"];
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(paymentGatewayURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("api-key", _configuration["api-key"]);
                JObject requestObject = JObject.FromObject(new
                {
                    creditCardInfo = creditCardNumber,
                    amount = amount
                });

                string json = JsonConvert.SerializeObject(requestObject);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = client.PostAsync(paymentGatewayURL, httpContent).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Payment failed!" + "{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("  Message: {0}", ex.Message);
                    throw ex;
                }
            }
            return true;
        }
    }
}
