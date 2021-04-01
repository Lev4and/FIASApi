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
    public class RegionsClientTests : IntegrationTest
    {
        private readonly RegionsClient _regionsClients;

        public RegionsClientTests()
        {
            _regionsClients = new RegionsClient(_client);
        }

        [Fact]
        public async Task GetRegion_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _regionsClients.GetRegion("27eb7c10-a234-44da-a59c-8b1f864966de");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VRegion>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VRegion));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegion_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _regionsClients.GetRegion("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VRegion>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VRegion));
            //TODO: for views default value not detected result.Should().Be(default(VRegion));
        }

        [Fact]
        public async Task GetRegions_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _regionsClients.GetRegions();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VRegion>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegions_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _regionsClients.GetRegions(100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VRegion>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _regionsClients.GetRegions(offname: "Челябинская", limit: 100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VRegion>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _regionsClients.GetRegions(offname: "Московская", limit: 100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VRegion>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
