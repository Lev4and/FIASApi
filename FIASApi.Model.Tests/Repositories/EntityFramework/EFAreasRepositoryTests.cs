using System;
using System.Collections.Generic;
using System.Linq;
using FIASApi.Model.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFAreasRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetArea_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VArea>(() =>
            {
                return _dataManager.Areas.GetArea("ab02da2d-ff0d-4bff-b27c-c921adee2a33");
            });

            result.Should().BeOfType(typeof(VArea));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetArea_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Areas.GetArea(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetAreas_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VArea>>(() =>
            {
                return _dataManager.Areas.GetAreas().ToList();
            });

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreas_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VArea>>(() =>
            {
                return _dataManager.Areas.GetAreas(10).ToList();
            });

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 10);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VArea>>(() =>
            {
                return _dataManager.Areas.GetAreas("Ка", "74", limit: 100).ToList();
            });

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAreasWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VArea>>(() =>
            {
                return _dataManager.Areas.GetAreas("Ка", "75", limit: 100).ToList();
            });

            result.Should().BeOfType(typeof(List<VArea>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
