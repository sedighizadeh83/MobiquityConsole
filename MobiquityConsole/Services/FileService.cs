using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobiquityConsole.Entities;

namespace MobiquityConsole.Services
{
    public class FileService
    {
        public IEnumerable<Package> GetAllTestCasesFromFile(string filePath)
        {
            List<Package> result = new List<Package>();
            string[] allLines = File.ReadAllLines(filePath);
            foreach (string line in allLines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var packageDTO = ParseStringLine(line);

                    result.Add(packageDTO);
                }
                else
                {
                    result.Add(new Package());
                }
            }

            return result;
        }

        //this method returns a package DTO from string line
        public Package ParseStringLine(string line)
        {
            Package packageDTO = new Package();
            var cleanLineWithoutSpaceAndCurrencySymbol = line.Replace("€", string.Empty).Replace(" ", string.Empty);
            packageDTO.Capacity = decimal.Parse(cleanLineWithoutSpaceAndCurrencySymbol.Split(':')[0].ToString());
            var itemsToChooseArray = cleanLineWithoutSpaceAndCurrencySymbol.Split(':')[1].Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in itemsToChooseArray)
            {
                string[] itemArray = item.Split(',');
                Item itemDTO = new Item(Convert.ToInt32(itemArray[0]), decimal.Parse(itemArray[1]), decimal.Parse(itemArray[2]));
                packageDTO.Items.Add(itemDTO);
            }

            return packageDTO;
        }
    }
}
