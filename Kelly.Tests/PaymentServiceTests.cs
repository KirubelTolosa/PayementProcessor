using Kelly.ApplicationService;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kelly.Tests
{
    public class PaymentServiceTests
    {
        private readonly Mock<IConfiguration> _mockedConfig;
        private readonly PaymentService _sut;

        public PaymentServiceTests()
        {
            _mockedConfig = new Mock<IConfiguration>();
            _sut = new PaymentService(_mockedConfig.Object);
        }

        [Fact]
        public void ChargeCard_InvalidCreditCardInput_ReturnFalse()
        {
            //Arrange
            _mockedConfig.SetupGet(r => r.GetSection("PaymentGatewaySettings")["PaymentGatewayURL"]).Returns("https://localhost:44381/api/PaymetProcessor/chargeCard");
            _mockedConfig.SetupGet(r => r["api-key"]).Returns("xxxx-xxxx-xxxx-xxxx");
            double amount = 49.99;
            CreditCardInfoApplicationServiceDto creditCardInfo = new CreditCardInfoApplicationServiceDto
            {
                CreditCardNumber = "477132059480",
                ExpirationDate = DateTime.Now.AddYears(2),
                NameOnCard = "Kirubel Tolosa",
                CVV = 123
            };

            //Act
            var result = _sut.ChargeCard(creditCardInfo, amount);

            //Assert
            Assert.False(result, "Invalid credit card information!");
        }

        [Fact]
        public void ChargeCard_RequestIsAboveBalance_ReturnFalse()
        {
            //Arrange
            _mockedConfig.SetupGet(r => r.GetSection("PaymentGatewaySettings")["PaymentGatewayURL"]).Returns("https://localhost:44381/api/PaymetProcessor/chargeCard");
            _mockedConfig.SetupGet(r => r["api-key"]).Returns("xxxx-xxxx-xxxx-xxxx");
            double amount = 149.99;
            CreditCardInfoApplicationServiceDto creditCardInfo = new CreditCardInfoApplicationServiceDto
            {
                CreditCardNumber = "4771320594033780",
                ExpirationDate = DateTime.Now.AddYears(2),
                NameOnCard = "Kirubel Tolosa",
                CVV = 123
            };

            //Act
            var result = _sut.ChargeCard(creditCardInfo, amount);

            //Assert
            Assert.False(result, "Not enough balance!");
        }

        [Fact]
        public void ChargeCard_InputsAreValid_ReturnTrue()
        {
            //Arrange
            _mockedConfig.SetupGet(r => r.GetSection("PaymentGatewaySettings")["PaymentGatewayURL"]).Returns("https://localhost:44382/api/PaymetProcessor/chargeCard");
            _mockedConfig.SetupGet(r => r["api-key"]).Returns("xxxx-xxxx-xxxx-xxxx");
            double amount = 49.99;
            CreditCardInfoApplicationServiceDto creditCardInfo = new CreditCardInfoApplicationServiceDto
            {
                CreditCardNumber = "4771320594033780",
                ExpirationDate = DateTime.Now.AddYears(2),
                NameOnCard = "Kirubel Tolosa",
                CVV = 123
            };

            //Act
            var result = _sut.ChargeCard(creditCardInfo, amount);

            //Assert
            Assert.True(result, "Payment complete!");
        }
    }
}
