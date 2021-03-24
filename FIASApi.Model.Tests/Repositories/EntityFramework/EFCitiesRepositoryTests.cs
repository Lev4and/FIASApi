using FIASApi.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFCitiesRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetCity_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VCity>(() =>
            {
                return _dataManager.Cities.GetCity("a376e68d-724a-4472-be7c-891bdb09ae32");
            });

            result.Should().BeOfType(typeof(VCity));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCity_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Cities.GetCity(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetCities_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VCity>>(() =>
            {
                return _dataManager.Cities.GetCities().ToList();
            });

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCities_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VCity>>(() =>
            {
                return _dataManager.Cities.GetCities(15).ToList();
            });

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VCity>>(() =>
            {
                return _dataManager.Cities.GetCities(offname: "Че", limit: 15).ToList();
            });

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c > 0 && c <= 15);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCitiesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VCity>>(() =>
            {
                return _dataManager.Cities.GetCities(offname: "Че", regionCode: "75", limit: 15).ToList();
            });

            result.Should().BeOfType(typeof(List<VCity>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
