using FIASApi.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Addrobs
{
    public class StreetsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetStreet_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/addrobs/streets/street/?aoguid=a7ce3904-4715-49dd-aa71-03018456ca72");
            var result = await response.Content.ReadAsAsync<VStreet>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VStreet));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreet_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAsync("api/addrobs/streets/street/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetStreets_WithoutAnyParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/streets/all/");
            var result = await response.Content.ReadAsAsync<List<VStreet>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreets_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/streets/all/?limit=250");
            var result = await response.Content.ReadAsAsync<List<VStreet>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/streets/search/?offname=Петра&regionCode=74&areaCode=000&cityCode=001&limit=250");
            var result = await response.Content.ReadAsAsync<List<VStreet>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollcetionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/streets/search/?offname=Петра&regionCode=75&areaCode=000&cityCode=001&limit=250");
            var result = await response.Content.ReadAsAsync<List<VStreet>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
