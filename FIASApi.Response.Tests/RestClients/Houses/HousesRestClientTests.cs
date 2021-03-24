using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Houses;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Houses
{
    public class HousesRestClientTests : IntegrationTest
    {
        private readonly HousesRestClient _housesRestClient;

        public HousesRestClientTests()
        {
            _housesRestClient = new HousesRestClient(_client);
        }

        [Fact]
        public async Task GetHouse_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _housesRestClient.GetHouse("f5056f41-feb7-470d-b2a5-cd27648108e2");

            result.Should().BeOfType(typeof(VHouse));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHouse_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _housesRestClient.GetHouse("");

            result.Should().BeOfType(typeof(VHouse));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetHouses_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _housesRestClient.GetHouses(50);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _housesRestClient.GetHouses(regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 50);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _housesRestClient.GetHouses(regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 50);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
