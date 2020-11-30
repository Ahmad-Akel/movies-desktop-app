using System;
using System.Linq;
using System.Threading.Tasks;

using Movies.Core.Services;

using Xunit;

namespace Movies.Core.Tests.XUnit
{
    // TODO WTS: Add appropriate unit tests.
    public class Tests
    {
        [Fact]
        public void Test1()
        {
        }

        // TODO WTS: Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsContentGridDataAsync()
        {
            var actual = await SampleDataService.GetContentGridDataAsync();

            Assert.NotEmpty(actual);
        }

        // TODO WTS: Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsGridDataAsync()
        {
            var actual = await SampleDataService.GetGridDataAsync();

            Assert.NotEmpty(actual);
        }

        // TODO WTS: Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsMasterDetailDataAsync()
        {
            var actual = await SampleDataService.GetMasterDetailDataAsync();

            Assert.NotEmpty(actual);
        }
    }
}
