namespace _12.QueenPuzzel
{
    using System;

    public class Program
    {
        public static void Main()
        {
            EightQueen queen = new EightQueen(8);
            queen.GetSolution(0);
        }
    }
    public class EightQueen
    {
        private int[] queenColumnPositions;
        private int count = 0;
        public int Size { get; set; }

        public EightQueen(int size)
        {
            this.Size = size;
            this.queenColumnPositions = new int[size];
        }
        public void GetSolution(int currentQueenColumn)
        {
            if (currentQueenColumn == this.Size)
            {
                PrintBoard();
                return;
            }

            for (int i = 0; i < this.Size; i++)
            {
                if (IsValidPosition(i, currentQueenColumn))
                {
                    this.queenColumnPositions[currentQueenColumn] = i;
                    GetSolution(currentQueenColumn + 1);
                }
            }
        }

        private bool IsValidPosition(int i, int currentQueenColumn)
        {
            for (int j = 0; j < currentQueenColumn; j++)
            {
                // column
                if (this.queenColumnPositions[j] == i)
                {
                    return false;
                }

                // diagonals
                if (Math.Abs(queenColumnPositions[j] - i)
                    == Math.Abs(j - currentQueenColumn))
                {
                    return false;
                }
            }
            return true;
        }

        private void PrintBoard()
        {
            count++;
            Console.WriteLine(count);
            foreach (int item in this.queenColumnPositions)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (j == item)
                        Console.Write("Q ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
