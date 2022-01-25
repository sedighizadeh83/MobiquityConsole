using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobiquityConsole.Entities;
using MobiquityConsole.Services;
using Xunit;

namespace MobiquityConsole.Test
{
    public class FileServiceTest
    {
		FileService fileService = new FileService();

		const string stringLine = "81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)";

		Package expected = new Package()
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
		};

		[Fact]
		public void GetAPackageFromStringLine_WhenFound_IsNotNull()
		{
			var package = fileService.ParseStringLine(stringLine);
			Assert.NotNull(package);
		}

		[Fact]
		public void GetAPackageFromStringLine_WhenFound_HasItems()
		{
			var package = fileService.ParseStringLine(stringLine);
			Assert.NotNull(package.Items);
		}

		[Fact]
		public void GetAPackageFromStringLine_WhenFound_HasExpectedCapacity()
		{
			var package = fileService.ParseStringLine(stringLine);
			Assert.Equal(expected.Capacity, package.Capacity);
		}

		[Fact]
		public void GetAPackageFromStringLine_WhenFound_HasExpectedItems()
		{
			var package = fileService.ParseStringLine(stringLine);
			Assert.Equal(expected.Items.ToString(), package.Items.ToString());
		}
	}
}
