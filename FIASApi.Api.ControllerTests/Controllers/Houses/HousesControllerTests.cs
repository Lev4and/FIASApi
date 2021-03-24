using FIASApi.Model.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Houses
{
    public class HousesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetHouse_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/houses/houses/house/?houseguid=f5056f41-feb7-470d-b2a5-cd27648108e2");
            var result = await response.Content.ReadAsAsync<VHouse>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VHouse));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHouse_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAsync("api/houses/houses/house/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetHouses_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/houses/houses/all/?limit=50");
            var result = await response.Content.ReadAsAsync<List<VHouse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/houses/houses/search/?regionCode=74&areaCode=000&cityCode=001&streetCode=0216&limit=50");
            var result = await response.Content.ReadAsAsync<List<VHouse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollcetionResponse()
        {
            var response = await _client.GetAsync("api/houses/houses/search/?regionCode=75&areaCode=000&cityCode=001&streetCode=0216&limit=50");
            var result = await response.Content.ReadAsAsync<List<VHouse>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
