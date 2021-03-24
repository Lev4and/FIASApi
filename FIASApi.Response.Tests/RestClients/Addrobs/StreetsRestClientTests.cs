using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Addrobs;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Addrobs
{
    public class StreetsRestClientTests : IntegrationTest
    {
        private readonly StreetsRestClient _streetsRestClient;

        public StreetsRestClientTests()
        {
            _streetsRestClient = new StreetsRestClient(_client);
        }

        [Fact]
        public async Task GetStreet_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _streetsRestClient.GetStreet("a7ce3904-4715-49dd-aa71-03018456ca72");

            result.Should().BeOfType(typeof(VStreet));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreet_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _streetsRestClient.GetStreet("");

            result.Should().BeOfType(typeof(VStreet));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetStreets_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _streetsRestClient.GetStreets();

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreets_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _streetsRestClient.GetStreets(250);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _streetsRestClient.GetStreets(offname: "Петра", regionCode: "74", areaCode: "000", cityCode: "001", limit: 250);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _streetsRestClient.GetStreets(offname: "Петра", regionCode: "75", areaCode: "000", cityCode: "001", limit: 250);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
