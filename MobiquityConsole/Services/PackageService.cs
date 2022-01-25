using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobiquityConsole.Entities;

namespace MobiquityConsole.Services
{
    public class PackageService
    {
        //this methods receive all test cases as input
        //for each test case tries the solution with Dynamic Programming
        //append all test cases' results and returns solution as string
        public string Pack(IEnumerable<Package> testCases)
        {
            string[] resultSet = new string[testCases.Count()];
            StringBuilder sb = new StringBuilder();
            foreach (Package testCase in testCases)
            {
                var result = DynamicProgrammingKnapsack(testCase);
                if (result != null && result.Count() > 0)
                {
                    if(testCase == testCases.Last())
                    {
                        sb.Append(String.Join(',', result.OrderBy(x => x.Id).Select(x => x.Id.ToString())));
                    }
                    else
                    {
                        sb.AppendLine(String.Join(',', result.OrderBy(x => x.Id).Select(x => x.Id.ToString())));
                    }
                }
                else
                {
                    if (testCase == testCases.Last())
                    {
                        sb.Append("-");
                    }
                    else
                    {
                        sb.AppendLine("-");
                    }
                }

            }
            return sb.ToString();
        }

        //Dynamic Programming implementation of Max Profit Knapsack 0/1 Problem
        //the reason that this algorithm is prefered to recursive solution is time complexity
        //time complexity is O(N*W)
        public IEnumerable<Item> DynamicProgrammingKnapsack(Package testCase)
        {
            List<Item> solutionItems = new List<Item>();
            testCase.Items.ForEach(x => x.SetWeight(x.Weight * 100));
            var itemsOrderedByWeight = testCase.Items.OrderBy(x => x.Weight).ToList();
            var normalizedCapacity = (int)testCase.Capacity * 100;
            var resultsMatrix = new decimal[itemsOrderedByWeight.Count() + 1, normalizedCapacity + 1];


            for (int i = 0; i <= itemsOrderedByWeight.Count(); i++)
            {
                for (int j = 0; j <= normalizedCapacity; j++)
                {
                    if (i == 0)
                    {
                        resultsMatrix[i, j] = 0;
                    }
                    else if (itemsOrderedByWeight[i - 1].Weight <= j)
                    {
                        resultsMatrix[i, j] = Math.Max(
                            resultsMatrix[i - 1, j],
                            itemsOrderedByWeight[i - 1].Cost + resultsMatrix[i - 1, j - (int)itemsOrderedByWeight[i - 1].Weight]
                            );
                    }
                    else
                    {
                        resultsMatrix[i, j] = resultsMatrix[i - 1, j];
                    }
                }
            }

            //the max profit value is on the last cell of the matrix
            decimal solutionPackageTotalCost = resultsMatrix[itemsOrderedByWeight.Count, normalizedCapacity];
            decimal solutionPackageTotalWeight = normalizedCapacity;

            //we start backtracking from the last cell of matrix and check which items to include
            //if the value comes from row above so the item in the current row is not included
            //if the value comes from the current row, the item in the current row is included and the cost and wieght is updated
            for (int i = itemsOrderedByWeight.Count; i > 0 && solutionPackageTotalCost > 0; i--)
            {
                if (solutionPackageTotalCost != resultsMatrix[i - 1, (int)solutionPackageTotalWeight])
                {
                    solutionItems.Add(itemsOrderedByWeight[i - 1]);
                    solutionPackageTotalCost -= itemsOrderedByWeight[i - 1].Cost;
                    solutionPackageTotalWeight -= itemsOrderedByWeight[i - 1].Weight;
                }
            }

            return solutionItems;
        }
    }
}
