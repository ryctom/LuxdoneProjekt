using CurrencyProject.Services.Validaton;

namespace CurrencyProject.Parameters
{
    public class CurrencyQueryParameter
    {
        [CodeValidation]
        public string Code { get; set; }
        [DateValidation]
        public string StartDate { get; set; }
        [DateValidation]
        public string EndDate { get; set; }
    }
}
