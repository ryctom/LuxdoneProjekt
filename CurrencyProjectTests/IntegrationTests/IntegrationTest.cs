using CurrencyProject;
using CurrencyProjectTests.IntegrationTests;
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
    }
}


