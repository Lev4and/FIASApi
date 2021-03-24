using FIASApi.Model.Entities;
using FIASApi.Response.RestClients.Addrobs;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Response.Tests.RestClients.Addrobs
{
    public class AreasRestClientTests : IntegrationTest
    {
        private readonly AreasRestClient _areasRestClient;

        public AreasRestClientTests()
        {
            _areasRestClient = new AreasRestClient(_client);
        }

        [Fact]
        public async Task GetArea_WithParams_ReturnNotBeNullResponse()
        {
            var result = await _areasRestClient.GetArea("ab02da2d-ff0d-4bff-b27c-c921adee2a33");

            result.Should().BeOfType(typeof(VArea));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetArea_WithoutAnyParams_ReturnBeDefaultObjectResponse()
        {
            var result = await _areasRestClient.GetArea("");

            result.Should().BeOfType(typeof(VArea));
            //TODO: Should check result on default value
        }

        [Fact]
        public async Task GetAreas_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _areasRestClient.GetAreas();

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreas_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _areasRestClient.GetAreas(10);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 10);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await _areasRestClient.GetAreas("Ка", "74", 100);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await _areasRestClient.GetAreas("Ка", "75", 100);

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
