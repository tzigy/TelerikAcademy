namespace _07.MatrixPassableCell
{
    public class Cell
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Distance { get; set; }

        public Cell(int row, int col, int distance)
        {
            this.Row = row;
            this.Col = col;
            this.Distance = distance;
        }
    }
}
