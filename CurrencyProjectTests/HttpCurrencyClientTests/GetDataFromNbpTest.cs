using CurrencyProject.HttpClients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CurrencyProjectTests.HttpCurrencyClientTests
{
    public class GetDataFromNbpTest
    {
        private HttpCurrencyClient _client = new HttpCurrencyClient();
        private string url = "http://api.nbp.pl/api/exchangerates/rates/C/eur";

        [Fact]
        public async Task CallNbpServiceForDataAsync()
        {
            // Act
            var json = await _client.GetExternalResponse(url, "application/json");

            // Assert
            Assert.NotEmpty(json);
        }
    }
}
