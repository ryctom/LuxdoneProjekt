using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CurrencyProject.Services.Validaton
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public static string _format =  "yyyy-mm-dd";

        public string GetWrongFormatErrorMessage(string date) =>
            $"Date parameter {date} has wrong format. Supported format: RRRR-MM-DD";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var code = (string)value;

            if (!IsValidDateFormat(code))
            {
                return new ValidationResult(GetWrongFormatErrorMessage(code));
            }
            
            return ValidationResult.Success;
        }

        public static bool IsValidDateFormat(string value)
        {
            DateTime tempDate;

            bool validDate = DateTime.TryParseExact(value,
                _format, 
                DateTimeFormatInfo.InvariantInfo, 
                DateTimeStyles.None, 
                out tempDate);

            if (validDate)
                return true;
            else
                return false;
        }
    }
}
