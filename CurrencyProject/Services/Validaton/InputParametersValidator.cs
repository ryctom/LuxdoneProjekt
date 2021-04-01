using CurrencyProject.Common;
using CurrencyProject.Exceptions;

namespace CurrencyProject.Services.Validaton
{
    public class InputParametersValidator : IValidation
    {
        public void Validate(string code, string startDate, string endDate)
        {
            if(!SupportedCurrency.IsCurrencySupported(code))
            {
                throw new NotSupportedCurrencyException(code);
            }
        }
    }
}
