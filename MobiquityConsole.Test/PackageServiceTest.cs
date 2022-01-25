using MobiquityConsole.Entities;
using MobiquityConsole.Services;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MobiquityConsole.Test
{
    public class PackageServiceTest
    {
        PackageService packageService = new PackageService();

        readonly string[] expected = { "4", "_", "2,7", "8,9" };

        List<Package> inputTestCases = new List<Package>()
            {
                new Package()
                {
                    Capacity = 81,
                    Items = new List<Item>()
                    {
                        new Item(1,(decimal)53.38,45),
                        new Item(2,(decimal)88.62,98),
                        new Item(3,(decimal)78.48,3),
                        new Item(4,(decimal)72.30,76),
                        new Item(5,(decimal)30.18,9),
                        new Item(6,(decimal)46.34,48)
                    }
                },
                new Package()
                {
                    Capacity = 8,
                    Items = new List<Item>()
                    {
                        new Item(1,(decimal)15.3,34)
                    }
                },
                new Package()
                {
                    Capacity = 75,
                    Items = new List<Item>()
                    {
                        new Item(1,(decimal)85.31,29),
                        new Item(2,(decimal)14.55,74),
                        new Item(3,(decimal)3.98,16),
                        new Item(4,(decimal)26.24,55),
                        new Item(5,(decimal)63.69,52),
                        new Item(6,(decimal)76.25,75),
                        new Item(7,(decimal)60.02,74),
                        new Item(8,(decimal)93.18,35),
                        new Item(9,(decimal)89.95,78)
                    }
                },
                new Package()
                {
                    Capacity = 56,
                    Items = new List<Item>()
                    {
                        new Item(1,(decimal)90.72,13),
                        new Item(2,(decimal)33.80,40),
                        new Item(3,(decimal)43.15,10),
                        new Item(4,(decimal)37.97,16),
                        new Item(5,(decimal)46.81,36),
                        new Item(6,(decimal)48.77,79),
                        new Item(7,(decimal)81.80,45),
                        new Item(8,(decimal)19.36,79),
                        new Item(9,(decimal)6.76,64)
                    }
                },
            };

        [Fact]
        public void GetResult_GivenTestCases_IsNotNull()
        {
            var result = packageService.Pack(inputTestCases);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetResult_GivenTestCases_HasOneResutlPerTestCase()
        {
            var result = packageService.Pack(inputTestCases);
            var resultArray = result.Split('\n');
            Assert.Equal(expected.Length, resultArray.Length);
        }

        [Fact]
        public void GetResult_GivenTestCases_ReturnsExpectedResult()
        {
            var result = packageService.Pack(inputTestCases);
            var resultArray = result.Split('\n');
            Assert.Equal(expected.ToString(), resultArray.ToString());
        }
    }
}