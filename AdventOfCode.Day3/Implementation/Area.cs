using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3.Implementation
{
    public class Area
    {
        public IEnumerable<IEnumerable<Position>> Grid;

        /// <summary>ctor</summary>
        /// <param name="input">..##</param>
        public Area(string input)
        {
            SetupArea(input);
        }

        private void SetupArea(string input)
        {
            var rows = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            Grid = rows.Select(row => row.Select(position => new Position(position)).ToList()).ToList();
        }

        public Position At(int rowIndex, int columnIndex)
        {
            var row = Grid.ElementAt(rowIndex);

            columnIndex = EnsureColumnIndexNeverOutOfBounds(columnIndex, row.Count());

            return row.ElementAt(columnIndex);
        }

        private int EnsureColumnIndexNeverOutOfBounds(int columnIndex, int rowCount)
        {
            return columnIndex % rowCount;
        }

        public long TraverseAndMeetTrees(Player player = null)
        {
            player ??= new Player(3, 1);
            var amountOfTreesEncountered = 0L;

            do
            {
                var position = At(player.Row, player.Column);

                if (position.IsTree) amountOfTreesEncountered++;

                player.GoToNextLocation();
            }
            while (player.Row < Grid.Count());

            return amountOfTreesEncountered;
        }
    }
}
