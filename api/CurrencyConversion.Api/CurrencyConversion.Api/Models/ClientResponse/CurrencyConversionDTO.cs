using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversion.Api.Models.ClientResponse
{
    public record CurrencyConversionDTO
    {
        public bool success { get; set; }
       [JsonProperty("base")]
        public string BaseCurrency { get; set; }
        public Dictionary<string, double> rates { get; set; }

    }
}
