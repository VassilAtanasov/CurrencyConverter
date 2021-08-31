using CurrencyConverter.Services;
using System;
using Xunit;

namespace CurrencyConverter.UnitTests
{
    public class RateServiceTests
    {
        private IRateService _rateService;
        private RatesConfig _rates;
        public RateServiceTests()
        {
            _rates = new RatesConfig() { { "EUR", 0.87815f }, { "GBP", 0.78569f }, { "CAD", 1.31715f } };
            _rateService = new RateService(_rates);
        }

        [Fact]
        public void GetExchangeRate_ToUSD_FromEUR_ReturnsExpectedRate()
        {
            var r = _rateService.GetExchangeRate("USD", "EUR");

            Assert.Equal(1 / _rates["EUR"], r);
        }

        [Fact]
        public void GetExchangeRate_ToGBP_FromUSD_ReturnsExpectedRate()
        {
            var r = _rateService.Convert("GBP", "USD", 1);
            Assert.Equal((double)Math.Round(_rates["GBP"], 2), r);
        }

        [Fact]
        public void Convert_ToGBP_FromEUR_ReturnsExpectedRate()
        {
            var r = _rateService.Convert("GBP", "EUR", 1);

            Assert.Equal((double)Math.Round(_rates["GBP"] / _rates["EUR"], 2), r);
        }

        [Fact]
        public void Sum_MixedCurrencies_ReturnsExpectedValue()
        {
            var expectedCAD = Math.Round(185.64f, 2);
            var roundedCAD = _rateService.Sum("EUR", 13.12f, "GBP", 99f, "CAD");

            Assert.Equal(expectedCAD, roundedCAD);
        }


        [Fact]
        public void GetExchangeRate_ToEUR_ReturnsExpectedRate()
        {
            var r = _rateService.GetExchangeRate("EUR", "USD");
            Assert.Equal(_rates["EUR"], r);
        }

        [Fact]
        public void GetRateFromUSD_ToMissingCurrency_ReturnsException()
        {
            // Arrange
            const string missingCurrency = "XXX";
            // Act
            var ex = Assert.Throws<ArgumentException>(() => _rateService.GetExchangeRate(missingCurrency, "USD"));

            // Assert
            Assert.Equal($"No rate data for {missingCurrency}", ex.Message);
        }

    }
}
