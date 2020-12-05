using AdventOfCode.Day5.Implementation;
using System;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day5
{
    public class Main
    {
        [Fact]
        public void Ctor_Part1_MaxSeatId()
        {
            var boardingPassStrings = Data.BoardingPasses.Split("\r\n").ToList();

            var maxSeatId = boardingPassStrings.Select(s => new BoardingPass(s)).Max(b => b.SeatId);

            Assert.Equal(980, maxSeatId);
        }

        [Fact]
        public void Search_Part2_YourSeat()
        {
            var boardingPassStrings = Data.BoardingPasses.Split("\r\n").ToList();

            var allPasses = boardingPassStrings.Select(s => new BoardingPass(s)).OrderBy(p => p.SeatId).ToList();
            var veryFront = allPasses.Min(p => p.Row);
            var veryBack = allPasses.Max(p => p.Row);

            var passes = allPasses.Where(p => p.Row != 0 && p.Row != veryBack).ToList();


            var seatId = 0;
            for (int i = 1; i < passes.Count - 1; i++)
            {
                var previousSeat = passes[i - 1];
                var seat = passes[i];
                var nextSeat = passes[i + 1];

                if (Math.Abs(seat.SeatId - previousSeat.SeatId) != 1)
                {
                    seatId = seat.SeatId - 1;
                    break;
                }

                if (Math.Abs(seat.SeatId - nextSeat.SeatId) != 1)
                {
                    seatId = seat.SeatId + 1;
                    break;
                }

            }


            Assert.Equal(0, seatId);
        }
    }
}
