using FIASApi.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FIASApi.Model.Tests.Repositories.EntityFramework
{
    public class EFRegionsRepositoryTests : BaseTest
    {
        [Fact]
        public async Task GetRegion_WithParams_ReturnNotBeNullResponse()
        {
            var result = await Task.Run<VRegion>(() =>
            {
                return _dataManager.Regions.GetRegion("27eb7c10-a234-44da-a59c-8b1f864966de");
            });

            result.Should().BeOfType(typeof(VRegion));
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegion_WithoutAnyParams_ReturnExceptionResponse()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Regions.GetRegion(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact]
        public async Task GetRegions_WithoutAnyParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VRegion>>(() =>
            {
                return _dataManager.Regions.GetRegions().ToList();
            });

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegions_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VRegion>>(() =>
            {
                return _dataManager.Regions.GetRegions(100).ToList();
            });

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnNotBeNullCollectionResponse()
        {
            var result = await Task.Run<List<VRegion>>(() =>
            {
                return _dataManager.Regions.GetRegions(offname: "Челябинская", limit: 100).ToList();
            });

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c > 0 && c <= 100);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRegionsWithFilters_WithParams_ReturnEmptyCollectionResponse()
        {
            var result = await Task.Run<List<VRegion>>(() =>
            {
                return _dataManager.Regions.GetRegions(offname: "Московская", limit: 100).ToList();
            });

            result.Should().BeOfType(typeof(List<VRegion>));
            result.Should().HaveCount(c => c == 0);
            result.Should().NotBeNull();
        }
    }
}
