using Newtonsoft.Json;

namespace CurrencyProject.Services.SerializeService
{
    public class JsonService : IDeserializationService
    {
        public TResult GetDataFromResponse<TResult>(string response)
        {
            return JsonConvert.DeserializeObject<TResult>(response);
        }
    }
}
