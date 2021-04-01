namespace CurrencyProject.Services.SerializeService
{
    public interface IDeserializationService
    {
        TResult GetDataFromResponse<TResult>(string response);
    }
}