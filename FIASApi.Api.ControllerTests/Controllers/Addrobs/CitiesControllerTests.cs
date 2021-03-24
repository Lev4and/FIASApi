using FIASApi.Model.Entities;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Api.ControllerTests.Controllers.Addrobs
{
    public class CitiesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetCity_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("api/addrobs/cities/city/?aoguid=a376e68d-724a-4472-be7c-891bdb09ae32");
            var result = await response.Content.ReadAsAsync<VCity>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VCity));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCity_WithoutAnyParams_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAsync("api/addrobs/cities/city/");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetCities_WithoutAnyParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/cities/all/");
            var result = await response.Content.ReadAsAsync<List<VCity>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCities_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/cities/all/?limit=15");
            var result = await response.Content.ReadAsAsync<List<VCity>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnHttpStatusCode200AndNotBeNullCollectionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/places/search/?offname=Че&limit=15");
            var result = await response.Content.ReadAsAsync<List<VCity>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnHttpStatusCode200AndEmptyCollcetionResponse()
        {
            var response = await _client.GetAsync("api/addrobs/places/search/?offname=Че&regionCode=75&limit=15");
            var result = await response.Content.ReadAsAsync<List<VCity>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
