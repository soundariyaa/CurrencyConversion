using CurrencyConversion.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CurrencyConversion.Tests.Fixtures
{
    public class CurrencyConversionFixtures
    {
        public ICurrencyConverterService CurrencyConverterService { get; set; }

        public CurrencyConversionFixtures()
        {
            IServiceProvider provider = new ServiceCollection()
                .AddScoped<ICurrencyConverterService, CurrencyConverterService>()
                .BuildServiceProvider();

            CurrencyConverterService = provider.GetService<ICurrencyConverterService>() ?? throw new Exception($"{nameof(CurrencyConverterService)} is null ");
        }
    }
}
