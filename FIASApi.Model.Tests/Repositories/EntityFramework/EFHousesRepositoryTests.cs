using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIASApi.Model.Entities;
using FluentAssertions;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFHousesRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetHouse_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VHouse>(() =>
            {
                return _dataManager.Houses.GetHouse("f5056f41-feb7-470d-b2a5-cd27648108e2");
            });

            result.Should().BeOfType(typeof(VHouse));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHouse_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Houses.GetHouse(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetHouses_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VHouse>>(() =>
            {
                return _dataManager.Houses.GetHouses(50).ToList();
            });

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VHouse>>(() =>
            {
                return _dataManager.Houses.GetHouses(regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 50).ToList();
            });

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c > 0 && c <= 50);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetHousesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VHouse>>(() =>
            {
                return _dataManager.Houses.GetHouses(regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 50).ToList();
            });

            result.Should().BeOfType(typeof(List<VHouse>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
