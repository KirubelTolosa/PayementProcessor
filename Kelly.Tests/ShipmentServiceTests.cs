using Kelly.ApplicationService;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kelly.Tests
{
    public class ShipmentServiceTests
    {
        private readonly Mock<IConfiguration> _mockedConfig;
        private readonly ShipmentService _sut;

        public ShipmentServiceTests()
        {
            _mockedConfig = new Mock<IConfiguration>();
            _sut = new ShipmentService(_mockedConfig.Object);
        }

        [Fact]
        public void SendEmailToShipping_InvalidProductName_ReturnFalse()
        {
            // Arrange
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["SendGridApiKey"]).Returns("xxxx-xxxx-xxxx-xxxx");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["OrderProcessorEmail"]).Returns("orderprocessor.test@kelly.com");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["OrderProcessorUser"]).Returns("KellyTestUser");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["ShipmentDeptEmail"]).Returns("shipment.test@kelly.com");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["ShipmentDeptUser"]).Returns("KellyShipment TestUser");

            string productName = "BookA";
            int amount = 15;
            bool test = true; //Making sure a real email is not sent during test.


            //Act
            var result = _sut.EmailShipmentOrder(productName, amount, test);

            //Assert
            Assert.Equal(result.Result, HttpStatusCode.InternalServerError);
        }
        [Fact]
        public void SendEmailToShipping_ValidProductName_ReturnsTrue()
        {
            // Arrange
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["SendGridApiKey"]).Returns("xxxx-xxxx-xxxx-xxxx");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["OrderProcessorEmail"]).Returns("orderprocessor.test@kelly.com");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["OrderProcessorUser"]).Returns("KellyTestUser");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["ShipmentDeptEmail"]).Returns("shipment.test@kelly.com");
            _mockedConfig.SetupGet(r => r.GetSection("EmailSettings")["ShipmentDeptUser"]).Returns("KellyShipment TestUser");

            string productName = "BookX";
            int amount = 15;
            bool test = true; //Making sure a real email is not sent during test.


            //Act
            var result = _sut.EmailShipmentOrder(productName, amount, test);

            //Assert
            Assert.Equal(result.Result, HttpStatusCode.OK);
        }
    }
}
