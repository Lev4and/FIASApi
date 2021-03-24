using FIASApi.Model.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Rooms
{
    public class OfficesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetOffice_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/rooms/offices/office/?roomguid=b2b65b92-cd36-480c-8a73-75a74e20f276");
            var result = await response.Content.ReadAsAsync<VOffice>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VOffice));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOffice_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAsync("api/rooms/offices/office/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetOffices_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/rooms/offices/all/?limit=25");
            var result = await response.Content.ReadAsAsync<List<VOffice>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 25);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/rooms/offices/search/?housenum=13&regionCode=74&areaCode=000&cityCode=001&streetCode=0298&limit=25");
            var result = await response.Content.ReadAsAsync<List<VOffice>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 25);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollcetionResponse()
        {
            var response = await _client.GetAsync("api/rooms/offices/search/?housenum=13&regionCode=75&areaCode=000&cityCode=001&streetCode=0298&limit=25");
            var result = await response.Content.ReadAsAsync<List<VOffice>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
