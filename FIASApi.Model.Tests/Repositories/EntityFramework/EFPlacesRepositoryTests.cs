using FIASApi.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFPlacesRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetPlace_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VPlace>(() =>
            {
                return _dataManager.Places.GetPlace("b693b0d3-2382-475d-9d00-6b55e495676d");
            });

            result.Should().BeOfType(typeof(VPlace));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlace_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Places.GetPlace(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetPlaces_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VPlace>>(() =>
            {
                return _dataManager.Places.GetPlaces().ToList();
            });

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlaces_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VPlace>>(() =>
            {
                return _dataManager.Places.GetPlaces(150).ToList();
            });

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VPlace>>(() =>
            {
                return _dataManager.Places.GetPlaces(offname: "Александровка", areaCode: "030", limit: 150).ToList();
            });

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c > 0 && c <= 150);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPlacesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VPlace>>(() =>
            {
                return _dataManager.Places.GetPlaces(offname: "Александровка", areaCode: "035", limit: 150).ToList();
            });

            result.Should().BeOfType(typeof(List<VPlace>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
