using FIASApi.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFFlatsRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetFlat_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VFlat>(() =>
            {
                return _dataManager.Flats.GetFlat("4c49302d-d116-457a-89b1-9b5986f13a01");
            });

            result.Should().BeOfType(typeof(VFlat));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlat_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Flats.GetFlat(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetFlats_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VFlat>>(() =>
            {
                return _dataManager.Flats.GetFlats(100).ToList();
            });

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VFlat>>(() =>
            {
                return _dataManager.Flats.GetFlats(housenum: "108", regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 100).ToList();
            });

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFlatsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VFlat>>(() =>
            {
                return _dataManager.Flats.GetFlats(housenum: "108", regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0216", limit: 100).ToList();
            });

            result.Should().BeOfType(typeof(List<VFlat>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
