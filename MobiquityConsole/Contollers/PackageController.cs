using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobiquityConsole.Entities;
using MobiquityConsole.Services;

namespace MobiquityConsole.Contollers
{
    public class PackageController
    {
        public string Pack(string filePath)
        {
            var fileService = new FileService();
            var packageService = new PackageService();

            //get all the test cases from file
            var testCases = fileService.GetAllTestCasesFromFile(filePath);

            //send all test cases to packer and get the result
            string result = packageService.Pack(testCases);

            return result;
        }
    }
}
