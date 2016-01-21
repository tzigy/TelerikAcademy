namespace _09.LargestConnectedArea
{
    using System;

    public class Program
    {
        private static int currentCount = 0;
        private static int maxCount = 0;
        private static char[,] matrix;

        public static void Main()
        {
            // Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.

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
                    currentCount = 0;
                    FindPath(row, col);
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                }
            }

            Console.WriteLine(maxCount);
        }

        private static void FindPath(int row, int col)
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
            currentCount++;
            FindPath(row - 1, col);
            FindPath(row, col + 1);
            FindPath(row + 1, col);
            FindPath(row, col - 1);
        }
    }
}
