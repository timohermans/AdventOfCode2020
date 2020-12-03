using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1.Implementation
{
    public record MatchFinder
    {
        public int TotalToMatch { get; init; }
        public int NumberOfElementsToMatch { get; init; }

        public IEnumerable<long> Find(string report)
        {
            var numbers = report.Split("\r\n").Select(n => Convert.ToInt64(n));

            var numbersFound = new List<long>();

            return GetMatchingNumbersFor(numbers, numbersFound, 1);
        }

        public IList<long> GetMatchingNumbersFor(IEnumerable<long> numbers, IList<long> numbersFound, int level, int? baseIndex = null)
        {
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (baseIndex != null && i == baseIndex) continue; 

                numbersFound.Add(numbers.ElementAt(i));

                if (level < NumberOfElementsToMatch)
                {
                    GetMatchingNumbersFor(numbers, numbersFound, level + 1, i);
                }

                if (level == NumberOfElementsToMatch)
                {
                    if (numbersFound.Aggregate((a, n) => a + n) == TotalToMatch && numbersFound.Count == NumberOfElementsToMatch)
                    {
                        return numbersFound;
                    }
                    

                    numbersFound.RemoveAt(numbersFound.Count - 1);
                }

                if (level < numbersFound.Count) // found them!
                {
                    Console.WriteLine("Found them!");
                    return numbersFound;
                }
            }

            numbersFound.RemoveAt(numbersFound.Count - 1);
            return numbersFound;
        }
    }
}
