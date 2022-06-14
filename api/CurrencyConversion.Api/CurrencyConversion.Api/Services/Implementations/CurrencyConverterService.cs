using CurrencyConversion.Api.Models.ClientResponse;
using System;

namespace CurrencyConversion.Api.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        public double Convert(CurrencyConversionDTO currencyConversionDTO, string fromCurrency, string toCurrency, double amount)
        {
           double convertedAmount = 0;
            if (fromCurrency == "USD")
            {
                convertedAmount = currencyConversionDTO.rates[toCurrency] * amount;
            }
            else
            {
                double fromCurrencyConversionRate = currencyConversionDTO.rates[fromCurrency];
                double toCurrencyConversionRate = currencyConversionDTO.rates[toCurrency];

                convertedAmount = (toCurrencyConversionRate / fromCurrencyConversionRate) * amount;
            }
                return Math.Truncate(100 * convertedAmount) / 100;
            
        }

    }
}
