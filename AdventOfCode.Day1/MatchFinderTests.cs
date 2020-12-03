using AdventOfCode.Day1.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Day1
{
    public class MatchFinderTests
    {
        [Fact]
        public void Find2020_SmallList_FindsCorrectMatch()
        {
            var report = @"979
366
1721
299
675
1456";

            var finder = new MatchFinder
            {
                TotalToMatch = 2020,
                NumberOfElementsToMatch = 2
            };

            var result = finder.Find(report);

            Assert.Equal(514579, result.Aggregate((a, n) => a * n));
        }

        [Fact]
        public void Find2020_SmallList_FindsCorrectMatchWith3()
        {
            var report = @"979
366
1721
299
675
1456";

            var finder = new MatchFinder
            {
                TotalToMatch = 2020,
                NumberOfElementsToMatch = 3
            };

            var result = finder.Find(report);

            // 979, 366, 675
            Assert.Equal(241861950, result.Aggregate((a, n) => a * n));
        }

    }
}
