namespace _08.MatrixSinglePath
{
    public class Program
    {
        public static void Main()
        {
            // We are given a matrix of passable and non-passable cells.
            // Write a recursive program for finding all paths between two cells in the matrix.

            // Modify the above program to check whether a path exists between two cells without finding all possible paths.
            // Test it over an empty 100 x 100 matrix.
            char[,] matrix =
           {
                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                {'*', '*', ' ', '*', ' ', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
            };

            char[,] matrix1 =
            {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', 'e'},
            };

            char[,] matrix2 = new char[100, 100];
            matrix2[99, 99] = 'e';

            var lab = new Labyrinth(matrix2);
            lab.FindPaths(0, 0, 'S');
        }
    }
}
