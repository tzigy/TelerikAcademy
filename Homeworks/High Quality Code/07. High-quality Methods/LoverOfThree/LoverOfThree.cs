namespace LoverOfThree
{
    using System;

    public class LoverOfThree
    {
        public static void Main()
        {            
            Console.WriteLine(CalculateSum());         
        }

        public static int CalculateSum()
        {
            string input = Console.ReadLine();
            int rows = GetNumberOfRows(input);
            int cols = GetNumberOfCols(input);
            string[,] field = InitiazeField(rows, cols);
            int numberOfOperations = GetNumberOfOperations();

            string operation;
            string currentDirection;
            int numberOfMoves;
            int result = 0;
            int currentRow = rows - 1;
            int currentCol = 0;

            for (int i = 0; i < numberOfOperations; i++)
            {
                operation = GetNextOperation();
                currentDirection = GetMoveDirection(operation);
                numberOfMoves = GetNumberOfMoves(operation) - 1;

                while (numberOfMoves != 0)
                {
                    numberOfMoves -= 1;

                    if (currentDirection.Equals("RU") ||
                        currentDirection.Equals("UR"))
                    {
                        if (currentRow == 0 ||
                           currentCol == cols - 1)
                        {
                            break;
                        }

                        currentRow -= 1;
                        currentCol += 1;
                    }

                    if (currentDirection.Equals("LU") ||
                        currentDirection.Equals("UL"))
                    {
                        if (currentRow == 0 ||
                           currentCol == 0)
                        {
                            break;
                        }

                        currentRow -= 1;
                        currentCol -= 1;
                    }

                    if (currentDirection.Equals("RD") ||
                        currentDirection.Equals("DR"))
                    {
                        if (currentRow == rows - 1 ||
                           currentCol == cols - 1)
                        {
                            break;
                        }

                        currentRow += 1;
                        currentCol += 1;
                    }

                    if (currentDirection.Equals("LD") ||
                        currentDirection.Equals("DL"))
                    {
                        if (currentRow == rows - 1 ||
                           currentCol == 0)
                        {
                            break;
                        }

                        currentRow += 1;
                        currentCol -= 1;
                    }

                    if (field[currentRow, currentCol] != "visited")
                    {
                        field[currentRow, currentCol] = "visited";

                        result += (3 * (rows - currentRow - 1)) + (3 * currentCol);
                    }
                }
            }

            return result;
        }

        private static int GetNumberOfRows(string input)
        {
            int numberOfRows = int.Parse(input.Split(' ')[0]);

            return numberOfRows;
        }

        private static int GetNumberOfCols(string input)
        {
            int numberOfCols = int.Parse(input.Split(' ')[1]);

            return numberOfCols;
        }

        private static int GetNumberOfOperations()
        {
            int numberOfOperations = int.Parse(Console.ReadLine());            
            return numberOfOperations;
        }

        private static string GetNextOperation()
        {
            string nextOperation = Console.ReadLine();
            return nextOperation;
        }

        private static string GetMoveDirection(string operation)
        {
            string direction = operation.Split(' ')[0];
            return direction;
        }

        private static int GetNumberOfMoves(string operation)
        {
            int numberOfMoves = int.Parse(operation.Split(' ')[1]);
            return numberOfMoves;
        }

        private static string[,] InitiazeField(int rows, int cols)
        {
            string[,] field = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = "not visited";
                }
            }

            return field;
        }        
    }
}