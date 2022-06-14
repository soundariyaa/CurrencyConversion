using CurrencyConversion.Api.Models.Request;
using FluentValidation;
using System.Linq;

namespace CurrencyConversion.Api.Validators
{
    public class CurrencyConversionRequestValidator : AbstractValidator<CurrencyConversionRequestModel>
    {
        public CurrencyConversionRequestValidator()
        {
            RuleFor(c => c.FromCurrency).Length(3);                
            RuleFor(c => c.ToCurrency).Length(3);
            RuleFor(c => c.Amount)
                .GreaterThan(0)    
                .WithMessage("Amount should be greater than 0 ");
        }
    }

}

