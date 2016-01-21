namespace _07._1.MatrixPaths
{
    using System;
    using System.Collections.Generic;

    internal class Labyrinth
    {
        private const char UNPASSABLE = '0';

        private char[,] matrix;
        private int[,] dir = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        private List<char> directions = new List<char>();

        public Labyrinth(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public void FindPaths(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (matrix[row, col] == '*' ||
                matrix[row, col] == UNPASSABLE)
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                PrintPath();
                return;
            }

            MarkCurrent(row, col);
            for (int i = 0; i < dir.GetLength(0); i++)
            {
                FindPaths(row + dir[i, 0], col + dir[i, 1]);
            }
            UnmarkCurrent(row, col);
        }

        private void UnmarkCurrent(int row, int col)
        {
            this.matrix[row, col] = ' ';
        }

        private void MarkCurrent(int row, int col)
        {
            this.matrix[row, col] = UNPASSABLE;
        }

        private void PrintPath()
        {
            Console.WriteLine("Paths");

            Console.WriteLine(string.Join(">", directions));
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write(" {0} |", this.matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}