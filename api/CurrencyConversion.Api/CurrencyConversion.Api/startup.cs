using CurrencyConversion.Api.Handler;
using CurrencyConversion.Api.Handler.Interfaces;
using CurrencyConversion.Api.HttpClients;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using CurrencyConversion.Api.HttpClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConversion.Api.Services;
using CurrencyConversion.Api.Helper;

[assembly: FunctionsStartup(typeof(CurrencyConversion.Api.startup))]
namespace CurrencyConversion.Api
{

    public class startup : FunctionsStartup
    {
        IConfiguration Configuration { get; set; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Get the azure function application directory. 'C:\whatever' for local and 'd:\home\whatever' for Azure
            var executionContextOptions = builder.Services.BuildServiceProvider()
                .GetService<IOptions<ExecutionContextOptions>>().Value;

            var currentDirectory = executionContextOptions.AppDirectory;

            // Get the original configuration provider from the Azure Function
            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

            // Create a new IConfigurationRoot and add our configuration along with Azure's original configuration 
            Configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddUserSecrets<startup>()
                // .addkeyvault
                .AddConfiguration(configuration) // Add the original function configuration 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Replace the Azure Function configuration with our new one
            builder.Services.AddSingleton(Configuration);
            builder.Services.AddMemoryCache();
            builder.Services.AddTransient<ICurrencyConversionClient, CurrencyConversionClient>();
            builder.Services.AddTransient<ICurrencyHandler, CurrencyHandler>();
            builder.Services.AddTransient<ICurrencyRateConversionCacheService, CurrencyRateConversionCacheService>();
            builder.Services.AddTransient<ICurrencyConverterService, CurrencyConverterService>();

        }
    }
}
