using AdventOfCode.Day5.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day5.Tests
{
    public class BoardingPassTests
    {
        [Fact]
        public void Ctor_SinglePass_ParsesRowCorrectly()
        {
            var boardingPassString = "BFFFBBFRRR";

            var pass = new BoardingPass(boardingPassString);

            Assert.Equal(70, pass.Row);
        }

        [Fact]
        public void Ctor_SinglePass_ParsesColumnCorrectly()
        {
            var boardingPassString = "BFFFBBFRRR";

            var pass = new BoardingPass(boardingPassString);

            Assert.Equal(7, pass.Column);
        }

        [Fact]
        public void Ctor_SinglePass_ParsesSeatIdCorrectly()
        {
            var boardingPassString = "BFFFBBFRRR";

            var pass = new BoardingPass(boardingPassString);

            Assert.Equal(567, pass.SeatId);
        }

        [Fact]
        public void Ctor_SinglePass2_ParsesCorreclty()
        {
            var boardingPassString = "FFFBBBFRRR";

            var pass = new BoardingPass(boardingPassString);

            Assert.Equal(14, pass.Row);
            Assert.Equal(7, pass.Column);
            Assert.Equal(119, pass.SeatId);
        }

        [Fact]
        public void Ctor_SinglePass3_ParsesCorreclty()
        {
            var boardingPassString = "BBFFBBFRLL";

            var pass = new BoardingPass(boardingPassString);

            Assert.Equal(102, pass.Row);
            Assert.Equal(4, pass.Column);
            Assert.Equal(820, pass.SeatId);
        }
    }
}
