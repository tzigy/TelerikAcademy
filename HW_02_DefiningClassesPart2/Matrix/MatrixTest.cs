namespace ClassMatrix
{
    using System;
    class MatrixTest
    {
        static void Main()
        {
            Matrix<int> firstMatrix = new Matrix<int>(2, 3);
            firstMatrix[0, 0] = 1;
            firstMatrix[0, 1] = 2;
            firstMatrix[0, 2] = 3;
            firstMatrix[1, 0] = 4;
            firstMatrix[1, 1] = 5;
            firstMatrix[1, 2] = 6;
            Console.WriteLine(firstMatrix);
            Matrix<int> secondMatrix = new Matrix<int>(2, 3);
            secondMatrix[0, 0] = 6;
            secondMatrix[0, 1] = 5;
            secondMatrix[0, 2] = 4;
            secondMatrix[1, 0] = 3;
            secondMatrix[1, 1] = 2;
            secondMatrix[1, 2] = 1;
            Console.WriteLine(secondMatrix);

            Console.WriteLine((firstMatrix + secondMatrix));
            Console.WriteLine((firstMatrix - secondMatrix));
            
            Matrix<int> thirdMatrix = new Matrix<int>(3, 3);
            thirdMatrix[0, 0] = 1;
            thirdMatrix[0, 1] = 2;
            thirdMatrix[0, 2] = 3;
            thirdMatrix[1, 0] = 4;
            thirdMatrix[1, 1] = 0;
            thirdMatrix[1, 2] = 6;
            thirdMatrix[2, 0] = 7;
            thirdMatrix[2, 1] = 8;
            thirdMatrix[2, 2] = 0;
            Console.WriteLine(thirdMatrix);

            Console.WriteLine((firstMatrix*thirdMatrix));

            if (firstMatrix)
            {
                Console.WriteLine("Matrix with non-zero elements!");
            }

            Matrix<decimal> fourthMatrix = new Matrix<decimal>(2, 7);
        }
    }
}
