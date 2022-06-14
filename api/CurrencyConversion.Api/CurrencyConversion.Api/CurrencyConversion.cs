using CurrencyConversion.Api.Handler.Interfaces;
using CurrencyConversion.Api.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CurrencyConversion.Api
{
    public class CurrencyConversion
    {
        public CurrencyConversion( ICurrencyHandler currencyHandler)
        {
            _currencyHandler = currencyHandler;
        }

        public ICurrencyHandler _currencyHandler;

        [FunctionName("CurrencyConversion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CurrencyConversionRequestModel data = JsonConvert.DeserializeObject<CurrencyConversionRequestModel> (requestBody);

            var result = await _currencyHandler.getCountryCurrency(data);
            return new OkObjectResult(result);

        }
    }
}
