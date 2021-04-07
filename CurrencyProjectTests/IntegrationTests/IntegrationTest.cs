using CurrencyProject;
using CurrencyProjectTests.IntegrationTests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;


namespace CurrencyProjectTests
{
    public class CurrencyApi_IntegrationTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public CurrencyApi_IntegrationTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task CurrencyRequestTest()
        {
            // Arrange
            var request = "/api/Currency/EUR/2021-03-20/2021-03-22";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UnavailiableCurrencyRequestTest()
        {
            // Arrange
            var request = "/api/Currency/PL/2021-03-20/2021-03-22";

            // Act
            var response = await Client.GetAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            var errors = JsonConvert.DeserializeObject<BadResponseCode>(result);

            // Assert
            Assert.Single(errors.Errors.Code);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task WrongDateFormatCurrencyRequestTest()
        {
            // Arrange
            var request = "/api/Currency/EUR/21-03-2020/22-03-2020";

            // Act
            var response = await Client.GetAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            var errors = JsonConvert.DeserializeObject<BadResponseDateFormat>(result);

            // Assert

            Assert.Single(errors.Errors.StartDate);
            Assert.Single(errors.Errors.EndDate);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}


