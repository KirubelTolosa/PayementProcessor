using Kelly.ApplicationService;
using Kelly.Repository;
using Moq;
using System;
using Xunit;

namespace Kelly.Tests
{
    public class InventoryServiceTests
    {
        private readonly Mock<IRepositoryService> _mockedRepositoryService;
        private readonly InventoryService _sut;

        public InventoryServiceTests()
        {
            _mockedRepositoryService = new Mock<IRepositoryService>();
            _sut = new InventoryService(_mockedRepositoryService.Object);
        }

        [Fact]
        public void IsProductAvailable_InputIsAvailable_ReturnTrue()
        {
            //Arrange
            _mockedRepositoryService.Setup(r => r.IsProductAvailable(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            var productName = "Wine";
            var amount = 2;

            //Act
            var result = _sut.IsProductAvailable(productName, amount);

            //Assert
            Assert.True(result, "There are enough items available in store!");
        }

        [Fact]
        public void IsProductAvailable_InputIsMoreThanAvailable_ReturnFalse() 
        {
            //Arrange
            _mockedRepositoryService.Setup(r => r.IsProductAvailable(It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            var productName = "Beer";
            var amount = 24;

            //Act
            var result = _sut.IsProductAvailable(productName, amount);

            //Assert
            Assert.False(result, "More items requested than available!");
        }

        [Fact]
        public void IsProductAvailable_InputIsNonExistentProduct_ReturnFalse()
        {
            //Arrange
            _mockedRepositoryService.Setup(r => r.IsProductAvailable(It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            var productName = "Apple";
            var amount = 24;

            //Act
            var result = _sut.IsProductAvailable(productName, amount);

            //Assert
            Assert.False(result, "Product does not exist in store!");
        }            
    }
    
}
