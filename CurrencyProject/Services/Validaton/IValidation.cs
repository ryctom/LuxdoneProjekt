namespace CurrencyProject.Services.Validaton
{
    public interface IValidation
    {
       void Validate(string code, string startDate, string endDate);
    }
}