namespace CurrencyConversion.Api.Models.Request
{
    public class CurrencyConversionRequestModel
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double Amount { get; set; }
    }
}
