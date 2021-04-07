using CurrencyProject.Common;
using System.ComponentModel.DataAnnotations;

namespace CurrencyProject.Services.Validaton
{
    public class CodeValidationAttribute : ValidationAttribute
    {  
        public string GetErrorMessage(string code) =>
            $"{code} currency is not supported by this service";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var code = (string)value;

            if (!SupportedCurrency.IsCurrencySupported(code))
            {
                return new ValidationResult(GetErrorMessage(code));
            }

            return ValidationResult.Success;
        }
    }
}

