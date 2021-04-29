using Kelly.ApplicationService.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kelly.ApplicationService
{
    public class ShipmentService : IShipmentService
    {
        private readonly IConfiguration _configuration;
        public ShipmentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HttpStatusCode> EmailShipmentOrder(string productName, int amount, bool test = false)
        {
            
            var sendGridClient = new SendGridClient(_configuration.GetSection("EmailSettings")["SendGridApiKey"]);
            var mailMessage = MailHelper.CreateSingleEmail(
                new EmailAddress(_configuration.GetSection("EmailSettings")["OrderProcessorEmail"], _configuration.GetSection("EmailSettings")["OrderProcessorUser"]),
                new EmailAddress(_configuration.GetSection("EmailSettings")["ShipmentDeptEmail"], _configuration.GetSection("EmailSettings")["ShipmentDeptUser"]),
                $"Placing an order for product: {productName}, amount {amount}",
                "Please deliver the given amount of items of the product to the address...",
                "<h1>Deliver Instruction</h1>"
                );

            #region //Logic for getting a list of possible products to ship (Included for testing reason)
            Dictionary<string, int> products = new Dictionary<string, int> {
                {"BookX", 50},
                {"BookY", 80 },
                {"BookZ", 15 }
            };
            return test && products.ContainsKey(productName) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            #endregion
            var response = await sendGridClient.SendEmailAsync(mailMessage);
            return response.StatusCode;
        }
    }
}