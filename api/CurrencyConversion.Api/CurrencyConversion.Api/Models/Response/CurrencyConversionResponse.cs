namespace CurrencyConversion.Api.Models.Response
{
    public class CurrencyConversionResponse 
    {
        public double ConvertedCurrency { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }


    }
}
