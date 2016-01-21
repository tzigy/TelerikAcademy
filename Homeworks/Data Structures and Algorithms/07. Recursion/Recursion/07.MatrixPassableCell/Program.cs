namespace _07.MatrixPassableCell
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // We are given a matrix of passable and non-passable cells.
            // Write a recursive program for finding all paths between two cells in the matrix.
            
            string[,] matrix =
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "e", "0" }
            };

            var lab = new Labyrinth(matrix);
            Cell startCell = new Cell(2, 1, 0);
            lab.FindPathsQ(startCell);
            lab.MarkUnreachableCells(startCell);
            Console.WriteLine("All Paths");
            lab.PrintMatrix();
        }
    }
}
