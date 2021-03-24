using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Rooms;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Rooms
{
    public class FlatsRestClientTests : IntegrationTest
    {
        private readonly FlatsRestClient _flatsRestClient;

        public FlatsRestClientTests()
        {
            _flatsRestClient = new FlatsRestClient(_client);
        }

        [Fact]
        public async Task GetFlat_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _flatsRestClient.GetFlat("4c49302d-d116-457a-89b1-9b5986f13a01");

            result.Should().BeOfType(typeof(VFlat));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlat_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _flatsRestClient.GetFlat("");

            result.Should().BeOfType(typeof(VFlat));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetFlats_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _flatsRestClient.GetFlats(100);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _flatsRestClient.GetFlats(housenum: "108", regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 100);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _flatsRestClient.GetFlats(housenum: "108", regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 100);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
