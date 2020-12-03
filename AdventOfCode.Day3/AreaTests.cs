using AdventOfCode.Day3.Implementation;
using System;
using Xunit;

namespace AdventOfCode.Day3
{
    public class AreaTests
    {
        [Fact]
        public void Ctor_Map2Rows_HasTreesAndEmptySpaces()
        {
            var area = new Area(@"
.#
#.");

            Assert.True(area.At(0, 0).IsOpen);
            Assert.True(area.At(0, 1).IsTree);
            Assert.True(area.At(1, 0).IsTree);
            Assert.True(area.At(1, 1).IsOpen);
        }

        [Fact]
        public void Ctor_Map1RowWith2Columns_HasOpenSpaceAt3()
        {
            var area = new Area(".#");

            Assert.True(area.At(0, 2).IsOpen);
        }

        [Fact]
        public void Ctor_Map1RowWith2Columns_HasTreeAt11()
        {
            var area = new Area(".#");

            Assert.True(area.At(0, 11).IsTree);
        }

        [Fact]
        public void Traverse_Map2Rows_1TreeEncountered()
        {
            var area = new Area(@".#..
...#");

            Assert.Equal(1, area.TraverseAndMeetTrees());
        }
    }
}
