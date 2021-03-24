using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Addrobs;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Addrobs
{
    public class PlacesRestClientTests : IntegrationTest
    {
        private readonly PlacesRestClient _placesRestClient;

        public PlacesRestClientTests()
        {
            _placesRestClient = new PlacesRestClient(_client);
        }

        [Fact]
        public async Task GetPlace_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _placesRestClient.GetPlace("b693b0d3-2382-475d-9d00-6b55e495676d");

            result.Should().BeOfType(typeof(VPlace));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlace_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _placesRestClient.GetPlace("");

            result.Should().BeOfType(typeof(VPlace));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetPlaces_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _placesRestClient.GetPlaces();

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlaces_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _placesRestClient.GetPlaces(150);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _placesRestClient.GetPlaces(offname: "Александровка", areaCode: "030", limit: 150);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _placesRestClient.GetPlaces(offname: "Александровка", areaCode: "035", limit: 150);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
