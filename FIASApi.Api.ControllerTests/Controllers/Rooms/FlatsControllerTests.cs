using FIASApi.Model.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Rooms
{
  
    public class FlatsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetFlat_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/rooms/flats/flat/?roomguid=4c49302d-d116-457a-89b1-9b5986f13a01");
            var result = await response.Content.ReadAsAsync<VFlat>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VFlat));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlat_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAsync("api/rooms/flats/flat/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetFlats_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/rooms/flats/all/?limit=10");
            var result = await response.Content.ReadAsAsync<List<VFlat>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 10);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/rooms/flats/search/?housenum=108&regionCode=74&areaCode=000&cityCode=001&streetCode=0216&limit=10");
            var result = await response.Content.ReadAsAsync<List<VFlat>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 10);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollcetionResponse()
        {
            var response = await _client.GetAsync("api/rooms/flats/search/?housenum=108&regionCode=75&areaCode=000&cityCode=001&streetCode=0216&limit=10");
            var result = await response.Content.ReadAsAsync<List<VFlat>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
