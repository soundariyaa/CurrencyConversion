using System.Threading.Tasks;

namespace CurrencyConversion.Api.HttpClients
{
    public interface ICurrencyConversionClient
    {
        Task<T> GetUSDCurrencyCoversions<T>() where T : new();
    }
}
