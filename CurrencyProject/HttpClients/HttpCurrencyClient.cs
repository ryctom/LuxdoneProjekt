using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CurrencyProject.HttpClients
{
    public class HttpCurrencyClient
    {
        private readonly HttpClient _nbpClient = new HttpClient();

        public async Task<string> GetExternalResponse(string url, string format)
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(15000); 
            client.DefaultRequestHeaders.ConnectionClose = true;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(format));
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
