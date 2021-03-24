using FIASApi.Model.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Addrobs
{
    public class RegionsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetRegion_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/addrobs/regions/region/?aoguid=27eb7c10-a234-44da-a59c-8b1f864966de");
            var result = await response.Content.ReadAsAsync<VRegion>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VRegion));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegion_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {

            var response = await _client.GetAsync("api/addrobs/regions/region/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetRegions_WithoutAnyParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/regions/all/");
            var result = await response.Content.ReadAsAsync<List<VRegion>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegions_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/regions/all/?limit=100");
            var result = await response.Content.ReadAsAsync<List<VRegion>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/regions/search/?offname=Челябинская&limit=100");
            var result = await response.Content.ReadAsAsync<List<VRegion>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollcetionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/regions/search/?offname=Московская&limit=100");
            var result = await response.Content.ReadAsAsync<List<VRegion>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
