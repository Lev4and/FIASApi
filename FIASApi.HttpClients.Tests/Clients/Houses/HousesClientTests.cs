using FIASApi.HttpClients.Clients.Houses;
using FIASApi.Model.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.HttpClients.Tests.Clients.Houses
{
    public class HousesClientTests : IntegrationTest
    {
        private readonly HousesClient _housesClient;

        public HousesClientTests()
        {
            _housesClient = new HousesClient(_client);
        }

        [Fact]
        public async Task GetHouse_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _housesClient.GetHouse("f5056f41-feb7-470d-b2a5-cd27648108e2");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VHouse>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VHouse));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHouse_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _housesClient.GetHouse("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VHouse>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VHouse));
            //TODO: for views default value not detected result.Should().Be(default(VHouse));
        }

        [Fact]
        public async Task GetHouses_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _housesClient.GetHouses(50);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VHouse>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _housesClient.GetHouses(regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 50);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VHouse>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _housesClient.GetHouses(regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 50);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VHouse>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
