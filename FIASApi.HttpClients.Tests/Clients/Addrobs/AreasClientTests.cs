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
    public class AreasClientTests : IntegrationTest
    {
        private readonly AreasClient _areasClient;

        public AreasClientTests()
        {
            _areasClient = new AreasClient(_client);
        }

        [Fact]
        public async Task GetArea_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _areasClient.GetArea("ab02da2d-ff0d-4bff-b27c-c921adee2a33");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VArea>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VArea));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetArea_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _areasClient.GetArea("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VArea>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VArea));
            //TODO: for views default value not detected result.Should().Be(default(VArea));
        }

        [Fact]
        public async Task GetAreas_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _areasClient.GetAreas();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VArea>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreas_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _areasClient.GetAreas(10);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VArea>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 10);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _areasClient.GetAreas("Ка", "74", limit: 100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VArea>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _areasClient.GetAreas("Ка", "75", limit: 100);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VArea>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
