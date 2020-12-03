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
        private bool _isMatchFound;

        public IEnumerable<long> Find(string report)
        {
            _isMatchFound = false;
            var numbers = report.Split("\r\n").Select(n => Convert.ToInt64(n)).ToList();

            var numbersFound = new long[NumberOfElementsToMatch];

            return GetMatchingNumbersFor(numbers, numbersFound, 1);
        }

        public IList<long> GetMatchingNumbersFor(IEnumerable<long> numbers, long[] numbersFound, int level, int? baseIndex = null)
        {
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (baseIndex != null && i == baseIndex) continue; 

                numbersFound[level - 1] = numbers.ElementAt(i);

                if (level < NumberOfElementsToMatch)
                {
                    GetMatchingNumbersFor(numbers, numbersFound, level + 1, i);
                }

                if (level == NumberOfElementsToMatch && numbersFound.Aggregate((a, n) => a + n) == TotalToMatch)
                {
                    _isMatchFound = true;
                }

                if (_isMatchFound)
                {
                    return numbersFound;
                }
            }

            return numbersFound;
        }
    }
}
