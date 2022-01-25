using MobiquityConsole.Exception;
using MobiquityConsole.Contollers;
using System.Text;
using System.IO;
using System.Reflection;
using Xunit;

namespace MobiquityConsole.Test
{
    public class PackerTest
    {
        PackageController packer = new PackageController();
        

        readonly string[] emptyArray = {""};
        readonly string[] notFoundFilePath = { "S:/notfoundfile" };

        [Fact]
        public void PassNoInputFilePath_ThrowsAPIException()
        {
            Assert.Throws<APIException>(() => Program.Main(emptyArray));
        }

        [Fact]
        public void PassNotFoundInputFilePath_ThrowsAPIException()
        {
            Assert.Throws<APIException>(() => Program.Main(notFoundFilePath));
        }

        [Fact]
        public void PassIncorrectFormatInputFilePath_ThrowsAPIException()
        {
            string[] incorrectFormatInputFile = { GetFullPathToFile("Resources/incorrect_format_input") };

            Assert.Throws<APIException>(() => Program.Main(incorrectFormatInputFile));
        }

        [Fact]
        public void PassCorrectInputFilePath_ReturnsExpectedResult()
        {
            string outputFile = GetFullPathToFile("Resources/example_output");
            string inputFile = GetFullPathToFile("Resources/example_input");
            string[] resultArray = packer.Pack(inputFile).Split("\r\n");
            string[] expectedResultArray = File.ReadAllLines(outputFile);

            for(int i = 0; i < resultArray.Length; i++)
            {
                Assert.Equal(expectedResultArray[i], resultArray[i]);
            }
        }

        internal static string GetFullPathToFile(string pathRelativeUnitTestingFile)
        {
            string pathAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string folderAssembly = System.IO.Path.GetDirectoryName(pathAssembly);
            if (folderAssembly.EndsWith("\\") == false) folderAssembly = folderAssembly + "\\";
            string folderProjectLevel = System.IO.Path.GetFullPath(folderAssembly + "..\\..\\..\\");

            string final = System.IO.Path.Combine(folderProjectLevel, pathRelativeUnitTestingFile);
            return final;
        }
    }
}