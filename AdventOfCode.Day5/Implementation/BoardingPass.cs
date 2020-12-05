using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Day5.Implementation
{
    [DebuggerDisplay("Seat ID: {SeatId}, Row: {Row}, Column: {Column}")]
    public class BoardingPass
    {
        private readonly string _boardingPassString;

        public int Row
        {
            get
            {
                var row = (0, 127);

                int rowId = 0;
                for (int i = 0; i < 7; i++)
                {
                    var nextCut = (row.Item1 + row.Item2) / 2;
                    var half = _boardingPassString[i];

                    if (half == 'F')
                    {
                        row.Item2 = nextCut;
                        rowId = row.Item2;
                    }
                    else if (half == 'B')
                    {
                        row.Item1 = nextCut + 1;
                        rowId = row.Item1;
                    }
                }

                return rowId;
            }
        }

        public int Column
        {
            get
            {
                var column = (0, 7);

                int columnId = 0;
                for (int i = 7; i < 10; i++)
                {
                    var nextCut = (column.Item1 + column.Item2) / 2;
                    var half = _boardingPassString[i];

                    if (half == 'L')
                    {
                        column.Item2 = nextCut;
                        columnId = column.Item2;
                    }
                    else if (half == 'R')
                    {
                        column.Item1 = nextCut + 1;
                        columnId = column.Item1;
                    }
                }

                return columnId;
            }
        }

        public int SeatId => Row * 8 + Column;

        public BoardingPass(string boardingPassString)
        {
            _boardingPassString = boardingPassString;
        }
    }
}
