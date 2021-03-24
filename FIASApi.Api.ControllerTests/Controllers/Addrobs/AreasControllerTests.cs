using FIASApi.Model.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Addrobs
{
    public class AreasControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetArea_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/addrobs/areas/area/?aoguid=ab02da2d-ff0d-4bff-b27c-c921adee2a33");
            var result = await response.Content.ReadAsAsync<VArea>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VArea));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetArea_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAsync("api/addrobs/areas/area/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAreas_WithoutAnyParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/areas/all/");
            var result = await response.Content.ReadAsAsync<List<VArea>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreas_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/areas/all/?limit=10");
            var result = await response.Content.ReadAsAsync<List<VArea>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 10);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/areas/search/?offname=Ка&regionCode=74&limit=100");
            var result = await response.Content.ReadAsAsync<List<VArea>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/areas/search/?offname=Ка&regionCode=75&limit=100");
            var result = await response.Content.ReadAsAsync<List<VArea>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
