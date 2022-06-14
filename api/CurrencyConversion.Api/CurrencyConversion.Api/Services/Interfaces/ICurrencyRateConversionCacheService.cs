using CurrencyConversion.Api.Models.ClientResponse;
using System.Threading.Tasks;

namespace CurrencyConversion.Api.Helper
{
    public interface ICurrencyRateConversionCacheService
    {
        Task<CurrencyConversionDTO> GetCurrencyConversionRates();
    }
}