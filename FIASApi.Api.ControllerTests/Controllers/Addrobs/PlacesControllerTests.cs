using FIASApi.Model.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Addrobs
{
    public class PlacesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetPlace_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/addrobs/places/place/?aoguid=b693b0d3-2382-475d-9d00-6b55e495676d");
            var result = await response.Content.ReadAsAsync<VPlace>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VPlace));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlace_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAsync("api/addrobs/places/place/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetPlaces_WithoutAnyParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/places/all/");
            var result = await response.Content.ReadAsAsync<List<VPlace>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlaces_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/places/all/?limit=150");
            var result = await response.Content.ReadAsAsync<List<VPlace>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/places/search/?offname=Александровка&areaCode=030&limit=150");
            var result = await response.Content.ReadAsAsync<List<VPlace>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollcetionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/places/search/?offname=Александровка&areaCode=035&limit=150");
            var result = await response.Content.ReadAsAsync<List<VPlace>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
