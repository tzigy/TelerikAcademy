namespace _10.AllAreasOfPassableCell
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static char[,] matrix;
        private static List<Cell> cells = new List<Cell>();

        public static void Main()
        {
            //*We are given a matrix of passable and non-passable cells.
            //Write a recursive program for finding all areas of passable cells in the matrix.

            matrix = new char[,]
           {
                { ' ', ' ', ' ', '*', ' ', ' ', ' '},
                { '*', '*', ' ', '*', ' ', '*', ' '},
                { ' ', ' ', ' ', '*', ' ', ' ', ' '},
                { '*', '*', '*', '*', '*', '*', ' '},
                { ' ', ' ', ' ', ' ', '*', '*', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '}
           };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '*')
                    {
                        continue;
                    }
                    if (matrix[row, col] == ' ')
                    {
                        FindAreas(row, col);
                        Console.WriteLine(string.Join(", ", cells));
                        PrintMatrix(cells);
                        cells.Clear();
                    }
                }
            }
        }

        private static void PrintMatrix(List<Cell> cells)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FindAreas(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }
            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            matrix[row, col] = 'v';
            cells.Add(new Cell(row, col));
            FindAreas(row - 1, col);
            FindAreas(row, col + 1);
            FindAreas(row + 1, col);
            FindAreas(row, col - 1);
        }
    }

    public class Cell
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.Row, this.Col);
        }
    }
}
