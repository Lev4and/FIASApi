using FIASApi.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFOfficesRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetOffice_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VOffice>(() =>
            {
                return _dataManager.Offices.GetOffice("b2b65b92-cd36-480c-8a73-75a74e20f276");
            });

            result.Should().BeOfType(typeof(VOffice));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOffice_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Offices.GetOffice(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetOffices_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VOffice>>(() =>
            {
                return _dataManager.Offices.GetOffices(250).ToList();
            });

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 250);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VOffice>>(() =>
            {
                return _dataManager.Offices.GetOffices(housenum: "13", regionCode: "74", areaCode: "000", cityCode: "001", streetCode: "0298", limit: 5).ToList();
            });

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c > 0 && c <= 5);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOfficesWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VOffice>>(() =>
            {
                return _dataManager.Offices.GetOffices(housenum: "13", regionCode: "75", areaCode: "000", cityCode: "001", streetCode: "0298", limit: 5).ToList();
            });

            result.Should().BeOfType(typeof(List<VOffice>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
