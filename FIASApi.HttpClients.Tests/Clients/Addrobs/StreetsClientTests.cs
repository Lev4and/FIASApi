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
    public class StreetsClientTests : IntegrationTest
    {
        private readonly StreetsClient _streetsClient;

        public StreetsClientTests()
        {
            _streetsClient = new StreetsClient(_client);
        }

        [Fact]
        public async Task GetStreet_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _streetsClient.GetStreet("a7ce3904-4715-49dd-aa71-03018456ca72");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VStreet>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VStreet));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreet_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _streetsClient.GetStreet("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VStreet>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VStreet));
            //TODO: for views default value not detected result.Should().Be(default(VStreet));
        }

        [Fact]
        public async Task GetStreets_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _streetsClient.GetStreets();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VStreet>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreets_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _streetsClient.GetStreets(250);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VStreet>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _streetsClient.GetStreets(offname: "Петра", regionCode: "74", areaCode: "000", cityCode: "001", limit: 250);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VStreet>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _streetsClient.GetStreets(offname: "Петра", regionCode: "75", areaCode: "000", cityCode: "001", limit: 250);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VStreet>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
