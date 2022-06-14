using CurrencyConversion.Api.Models.ClientResponse;
using CurrencyConversion.Api.Services;
using CurrencyConversion.Tests.Fixtures;
using System.Collections.Generic;
using Xunit;

namespace CurrencyConversion.Tests
{
    public class CurrencyConverterServiceTests : IClassFixture<CurrencyConversionFixtures>
    {

        public CurrencyConverterServiceTests(CurrencyConversionFixtures currencyConversionFixtures)
        {
            CurrencyConversionFixtures = currencyConversionFixtures;
        }

        public CurrencyConversionFixtures CurrencyConversionFixtures { get; }

        [Fact]
        public void ConvertCurrency_ConvertAEDToAFN_ExpectedOutput()
        {
            // Arrange
            CurrencyConversionDTO currencyConversionData = new CurrencyConversionDTO()
            {
                rates = new System.Collections.Generic.Dictionary<string, double>
                {
                   { "AED", 3.673097 },
                   {"AFN", 88.999979 }
                }
            };


            string fromCurrencyName = "AED";
            string toCurrencyName = "AFN";
            double amount = 55;
            double expectedAmount = 1332.66;
            ICurrencyConverterService sut = CurrencyConversionFixtures.CurrencyConverterService;

            // Act
            double convertedAmount = sut.Convert(currencyConversionData, fromCurrencyName, toCurrencyName, amount);

            // Assert
            Assert.Equal(convertedAmount,expectedAmount);
        }

    }
}