using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Addrobs;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Addrobs
{
    public class RegionsRestClientTests : IntegrationTest
    {
        private readonly RegionsRestClient _regionsRestClient;

        public RegionsRestClientTests()
        {
            _regionsRestClient = new RegionsRestClient(_client);
        }

        [Fact]
        public async Task GetRegion_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _regionsRestClient.GetRegion("27eb7c10-a234-44da-a59c-8b1f864966de");

            result.Should().BeOfType(typeof(VRegion));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegion_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _regionsRestClient.GetRegion("");

            result.Should().BeOfType(typeof(VRegion));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetRegions_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _regionsRestClient.GetRegions();

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegions_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _regionsRestClient.GetRegions(100);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _regionsRestClient.GetRegions(offname: "Челябинская", limit: 100);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _regionsRestClient.GetRegions(offname: "Московская", limit: 100);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
