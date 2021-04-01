using FIASApi.HttpClients.Clients.Addrobs;
using FIASApi.Model.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.HttpClients.Tests.Clients.Addrobs
{
    public class CitiesClientTests : IntegrationTest
    {
        private readonly CitiesClient _citiesClient;

        public CitiesClientTests()
        {
            _citiesClient = new CitiesClient(_client);
        }

        [Fact]
        public async Task GetCity_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _citiesClient.GetCity("a376e68d-724a-4472-be7c-891bdb09ae32");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VCity>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VCity));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCity_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _citiesClient.GetCity("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VCity>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VCity));
            //TODO: for views default value not detected result.Should().Be(default(VCity));
        }

        [Fact]
        public async Task GetCities_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _citiesClient.GetCities();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VCity>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCities_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _citiesClient.GetCities(15);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VCity>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _citiesClient.GetCities(offname: "Че", limit: 15);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VCity>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _citiesClient.GetCities(offname: "Че", regionCode: "75", limit: 15);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VCity>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
