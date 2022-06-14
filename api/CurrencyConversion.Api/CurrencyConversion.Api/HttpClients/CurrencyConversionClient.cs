using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CurrencyConversion.Api.Models.ClientResponse;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversion.Api.HttpClients
{
    public class CurrencyConversionClient : ICurrencyConversionClient
    {
        private string allCountryCurrencies;

        public CurrencyConversionClient(
            IConfiguration configuration,    
            HttpClient httpClient)
        {
            Configuration = configuration;
            _client = httpClient;
            _client.BaseAddress = new Uri("https://api.apilayer.com/");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public IConfiguration Configuration { get; }
        public HttpClient _client { get; }

        public async Task<T> GetUSDCurrencyCoversions<T>() where T : new()
        {
            string apiKey = Configuration["ApiKey"];
            var request = new HttpRequestMessage(HttpMethod.Get,
               $"/fixer/latest?baseCountry&apikey={apiKey}");

            using (var response = await _client.SendAsync(request,
              HttpCompletionOption.ResponseHeadersRead
              ))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var reader = new StreamReader(stream);
                return JsonConvert.DeserializeObject<T>(await reader.ReadToEndAsync());
            }
        }
    }
}
