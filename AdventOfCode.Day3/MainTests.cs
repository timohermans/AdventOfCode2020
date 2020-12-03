using AdventOfCode.Day3.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Day3
{
    public class MainTests
    {
        [Fact]
        public void Traverse_Part1_TreesEncountered()
        {
            var area = new Area(Data.Map);

            var amountOfTreesEncountered = area.TraverseAndMeetTrees();

            Assert.Equal(242, amountOfTreesEncountered);
        }

        [Fact]
        public void Traverse_Part2_TreesEncounteredWithDifferentPlayers()
        {
            var area = new Area(Data.Map);

            var trees1 = area.TraverseAndMeetTrees(new Player(1, 1));
            var trees2 = area.TraverseAndMeetTrees(new Player(3, 1));
            var trees3 = area.TraverseAndMeetTrees(new Player(5, 1));
            var trees4 = area.TraverseAndMeetTrees(new Player(7, 1));
            var trees5 = area.TraverseAndMeetTrees(new Player(1, 2));

            Assert.Equal(2265549792L, trees1 * trees2 * trees3 * trees4 * trees5);
        }

    }
}
