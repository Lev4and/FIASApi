using FIASApi.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFStreetsRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetStreet_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VStreet>(() =>
            {
                return _dataManager.Streets.GetStreet("a7ce3904-4715-49dd-aa71-03018456ca72");
            });

            result.Should().BeOfType(typeof(VStreet));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreet_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Streets.GetStreet(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetStreets_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VStreet>>(() =>
            {
                return _dataManager.Streets.GetStreets().ToList();
            });

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreets_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VStreet>>(() =>
            {
                return _dataManager.Streets.GetStreets(250).ToList();
            });

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VStreet>>(() =>
            {
                return _dataManager.Streets.GetStreets(offname: "Петра", regionCode: "74", areaCode: "000", cityCode: "001", limit: 250).ToList();
            });

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetStreetsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VStreet>>(() =>
            {
                return _dataManager.Streets.GetStreets(offname: "Петра", regionCode: "75", areaCode: "000", cityCode: "001", limit: 250).ToList();
            });

            result.Should().BeOfType(typeof(List<VStreet>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
