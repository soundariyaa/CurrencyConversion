using CurrencyConversion.Api.Models.ClientResponse;

namespace CurrencyConversion.Api.Services
{
    public interface ICurrencyConverterService
    {
        double Convert(CurrencyConversionDTO currencyConversionDTO, string fromCurrency, string toCurrency, double amount);
    }
}