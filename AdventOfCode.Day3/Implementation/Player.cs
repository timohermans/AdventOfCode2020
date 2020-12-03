namespace AdventOfCode.Day3.Implementation
{
    public record Player
    {
        public int Row { get; private set; }

        public int Column { get; private set; }
        public int RowStep { get; private set; }
        public int ColumnStep { get; private set; }

        public Player(int columnStep, int rowStep)
        {
            Row = 0;
            Column = 0;
            RowStep = rowStep;
            ColumnStep = columnStep;
        }

        public void GoToNextLocation()
        {
            Row += RowStep;
            Column += ColumnStep;
        }
    };

}
