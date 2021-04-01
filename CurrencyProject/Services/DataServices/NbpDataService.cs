using CurrencyProject.HttpClients;
using CurrencyProject.Model;
using CurrencyProject.Services.SerializeService;
using CurrencyProject.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyProject.Services.DataService
{
    public class NbpCurrencyService : IDataService
    {
        private readonly IOptions<NbpExternalServiceSettings> _settings;
        private readonly HttpCurrencyClient _hbpHttpClient;
        private readonly IDeserializationService _deserializationService;

        public NbpCurrencyService(
            IOptions<NbpExternalServiceSettings> settings,
            HttpCurrencyClient client,
            IDeserializationService deserializationService
            )
        {
            _settings = settings;
            _hbpHttpClient = client;
            _deserializationService = deserializationService;
        }

        public async Task<IEnumerable<CurrencyData>> GetCurrencyBeetweenDatesAsync(string code, string startTime, string endTime)
        {
            string url = GetUrlForCurrentCurrencies(code, startTime, endTime);

            var response = await _hbpHttpClient.GetExternalResponse(url, _settings.Value.Format);

            return _deserializationService.GetDataFromResponse<CurrencyResuts>(response).Rates;      
        }

        private string GetUrlForCurrentCurrencies(string code, string startTime, string endTime)
        {
            return _settings.Value.BaseUrl + "/" + code + "/" + startTime + "/" + endTime;
        }
    }
}
