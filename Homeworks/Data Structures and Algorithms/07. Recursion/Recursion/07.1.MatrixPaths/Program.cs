namespace _07._1.MatrixPaths
{
    public class Program
    {
        public static void Main()
        {
            // We are given a matrix of passable and non-passable cells.
            // Write a recursive program for finding all paths between two cells in the matrix.

            char[,] matrix =
           {
                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                {'*', '*', ' ', '*', ' ', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
            };

            var lab = new Labyrinth(matrix);
            lab.FindPaths(0, 0);
        }
    }
}
