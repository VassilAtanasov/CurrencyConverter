using CurrencyConverter.Controllers;
using CurrencyConverter.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace CurrencyConverter.UnitTests
{
    public class CurrencyControllerTests
    {
        [Fact]
        public void Rate_ToEur_ReturnsCorrectRate()
        {
            // Arrange
            var loggerStub = new Mock<ILogger<CurrencyController>>();
            var rateServiceStub = new Mock<IRateService>();
            var controller = new CurrencyController(loggerStub.Object, rateServiceStub.Object);

            // Act
            var result = controller.Rate("USD", "EUR");

            // Assert
            Assert.IsType<double>(result);
        }

        [Fact]
        public void Sum_WithEur_ReturnsCorrectRate()
        {
            // Arrange
            var loggerStub = new Mock<ILogger<CurrencyController>>();
            var rateServiceStub = new Mock<IRateService>();
            rateServiceStub
                .Setup(x => x.Sum(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<string>(), It.IsAny<double>(), It.IsAny<string>()))
                .Returns(1);
            var controller = new CurrencyController(loggerStub.Object, rateServiceStub.Object);

            // Act
            var result = controller.Sum("AAA", 1, "BBB", 1, "CCC");

            // Assert
            Assert.IsType<double>(result);
        }
    }
}
