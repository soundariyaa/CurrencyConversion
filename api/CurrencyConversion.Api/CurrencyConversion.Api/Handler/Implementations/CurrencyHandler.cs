using CurrencyConversion.Api.Handler.Interfaces;
using CurrencyConversion.Api.Helper;
using CurrencyConversion.Api.HttpClients;
using CurrencyConversion.Api.Models.ClientResponse;
using CurrencyConversion.Api.Models.Request;
using CurrencyConversion.Api.Models.Response;
using CurrencyConversion.Api.Services;
using CurrencyConversion.Api.Validators;
using System;
using System.Threading.Tasks;

namespace CurrencyConversion.Api.Handler
{
    public class CurrencyHandler : ICurrencyHandler
    {
        private readonly ICurrencyRateConversionCacheService _currencyConversionClient;
        private ICurrencyConverterService _currencyConverterService { get; }

        public CurrencyHandler(ICurrencyRateConversionCacheService currencyConversionClient, ICurrencyConverterService currencyConverterService )
        {
            _currencyConversionClient = currencyConversionClient;
            _currencyConverterService = currencyConverterService;
        }

        public async Task<CurrencyConversionResponse> getCountryCurrency(CurrencyConversionRequestModel currencyConversionRequest)
        {
            try
            {
                var validator = new CurrencyConversionRequestValidator().Validate(currencyConversionRequest);

                if (!validator.IsValid)
                {
                    throw new Exception($"In-parameter validation failed. {validator}.");
                }
                CurrencyConversionDTO allCountryCurrencies = await _currencyConversionClient.GetCurrencyConversionRates();
                double convertedAmount = _currencyConverterService.Convert(
                    allCountryCurrencies,
                    currencyConversionRequest.FromCurrency,
                    currencyConversionRequest.ToCurrency,
                    currencyConversionRequest.Amount);

                return new CurrencyConversionResponse
                {
                    ConvertedCurrency = convertedAmount,
                    IsSuccessful = true

                };
            }
            catch (Exception ex)
            {
                return new CurrencyConversionResponse
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.Message

                };
            }
        }
    }
}
