using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConversion.Api.HttpClients;
using CurrencyConversion.Api.Models.ClientResponse;
using Microsoft.Extensions.Caching.Memory;
using static CurrencyConversion.Api.Common.Constant;


namespace CurrencyConversion.Api.Helper
{
    public class CurrencyRateConversionCacheService : ICurrencyRateConversionCacheService
    {
        public CurrencyRateConversionCacheService(
            IMemoryCache cache,
             ICurrencyConversionClient currencyClient)
        {
            _cache = cache;
            _currencyClient = currencyClient;
        }

        private IMemoryCache _cache { get; }
        private ICurrencyConversionClient _currencyClient { get; }

        public async Task<CurrencyConversionDTO> GetCurrencyConversionRates()
        {
            _cache.TryGetValue(ConcurencyCacheKey, out CurrencyConversionDTO currencyConversionData);

            if (currencyConversionData == null)
            {
                currencyConversionData = await _currencyClient.GetUSDCurrencyCoversions<CurrencyConversionDTO>();
                _cache.Set(ConcurencyCacheKey, currencyConversionData);
            }

            return currencyConversionData;
        }
    }
}
