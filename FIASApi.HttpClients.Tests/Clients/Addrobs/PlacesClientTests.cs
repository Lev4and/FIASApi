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
    public class PlacesClientTests : IntegrationTest
    {
        private readonly PlacesClient _placesClient;

        public PlacesClientTests()
        {
            _placesClient = new PlacesClient(_client);
        }

        [Fact]
        public async Task GetPlace_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _placesClient.GetPlace("b693b0d3-2382-475d-9d00-6b55e495676d");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VPlace>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VPlace));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlace_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _placesClient.GetPlace("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VPlace>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VPlace));
            //TODO: for views default value not detected result.Should().Be(default(VPlace));
        }

        [Fact]
        public async Task GetPlaces_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _placesClient.GetPlaces();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VPlace>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlaces_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _placesClient.GetPlaces(150);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VPlace>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _placesClient.GetPlaces(offname: "Александровка", areaCode: "030", limit: 150);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VPlace>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _placesClient.GetPlaces(offname: "Александровка", areaCode: "035", limit: 150);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VPlace>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
