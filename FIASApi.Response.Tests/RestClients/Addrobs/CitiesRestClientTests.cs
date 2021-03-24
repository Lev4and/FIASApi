using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Addrobs;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Addrobs
{
    public class CitiesRestClientTests : IntegrationTest
    {
        private readonly CitiesRestClient _citiesRestClient;

        public CitiesRestClientTests()
        {
            _citiesRestClient = new CitiesRestClient(_client);
        }

        [Fact]
        public async Task GetCity_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _citiesRestClient.GetCity("a376e68d-724a-4472-be7c-891bdb09ae32");

            result.Should().BeOfType(typeof(VCity));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCity_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _citiesRestClient.GetCity("");

            result.Should().BeOfType(typeof(VCity));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetCities_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _citiesRestClient.GetCities();

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCities_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _citiesRestClient.GetCities(15);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _citiesRestClient.GetCities(offname: "Че", limit: 15);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _citiesRestClient.GetCities(offname: "Че", regionCode: "75", limit: 15);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
