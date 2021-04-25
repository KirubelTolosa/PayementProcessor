using Kelly.ApplicationService.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
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

        public async Task<Response> EmailShipmentOrder(string productName, int amount)
        {
            var shippingDepartmentEmail = _configuration["ShippingEmail"];
            var sendGridClient = new SendGridClient("API_KEY");
            var from = new EmailAddress("from email", "from user");
            var subject = "subject";
            var to = new EmailAddress("to email", "to name");
            var plainContent = "Hello";
            var htmlContent = "<h1>Hello</h1>";
            var mailMessage = MailHelper.CreateSingleEmail(from, to, subject, plainContent, htmlContent);
            var response = await sendGridClient.SendEmailAsync(mailMessage);

            return response;
        }
    }
}
