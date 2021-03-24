using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Rooms;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Rooms
{
    public class OfficesRestClientTests : IntegrationTest
    {
        private readonly OfficesRestClient _officesRestClient;

        public OfficesRestClientTests()
        {
            _officesRestClient = new OfficesRestClient(_client);
        }

        [Fact]
        public async Task GetOffice_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _officesRestClient.GetOffice("b2b65b92-cd36-480c-8a73-75a74e20f276");

            result.Should().BeOfType(typeof(VOffice));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOffice_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _officesRestClient.GetOffice("");

            result.Should().BeOfType(typeof(VOffice));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetOffices_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _officesRestClient.GetOffices(250);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _officesRestClient.GetOffices(housenum: "13", regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0298", limit: 5);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 5);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _officesRestClient.GetOffices(housenum: "13", regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0298", limit: 5);

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
