using FIASApi.HttpClients.Clients.Rooms;
using FIASApi.Model.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.HttpClients.Tests.Clients.Rooms
{
    public class FlatsClientTests : IntegrationTest
    {
        private readonly FlatsClient _flatsClient;

        public FlatsClientTests()
        {
            _flatsClient = new FlatsClient(_client);
        }

        [Fact]
        public async Task GetFlat_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _flatsClient.GetFlat("4c49302d-d116-457a-89b1-9b5986f13a01");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VFlat>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VFlat));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlat_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _flatsClient.GetFlat("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VFlat>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VFlat));
            //TODO: for views default value not detected result.Should().Be(default(VFlat));
        }

        [Fact]
        public async Task GetFlats_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _flatsClient.GetFlats(100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VFlat>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _flatsClient.GetFlats(housenum: "108", regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VFlat>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _flatsClient.GetFlats(housenum: "108", regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VFlat>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
