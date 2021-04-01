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
    public class OfficesClientTests : IntegrationTest
    {
        private readonly OfficesClient _officesClient;

        public OfficesClientTests()
        {
            _officesClient = new OfficesClient(_client);
        }

        [Fact]
        public async Task GetOffice_WithParams_ReturnNotBeNullResponse()
        {
            var response = await _officesClient.GetOffice("b2b65b92-cd36-480c-8a73-75a74e20f276");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VOffice>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(VOffice));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOffice_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var response = await _officesClient.GetOffice("");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VOffice>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            result.Should().BeOfType(typeof(VOffice));
            //TODO: for views default value not detected result.Should().Be(default(VOffice));
        }

        [Fact]
        public async Task GetOffices_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _officesClient.GetOffices(250);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VOffice>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var response = await _officesClient.GetOffices(housenum: "13", regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0298", limit: 5);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VOffice>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 5);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var response = await _officesClient.GetOffices(housenum: "13", regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0298", limit: 5);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VOffice>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
