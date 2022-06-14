using CurrencyConversion.Api.Models.Request;
using CurrencyConversion.Api.Models.Response;
using System.Threading.Tasks;

namespace CurrencyConversion.Api.Handler.Interfaces
{
    public interface ICurrencyHandler
    {
        Task<CurrencyConversionResponse> getCountryCurrency(CurrencyConversionRequestModel currencyConversionRequest);
    }
}
