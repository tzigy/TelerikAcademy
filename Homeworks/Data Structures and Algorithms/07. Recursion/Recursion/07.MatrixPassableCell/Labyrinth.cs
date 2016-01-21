namespace _07.MatrixPassableCell
{
    using System;
    using System.Collections.Generic;

    public class Labyrinth
    {
        private string[,] matrix;
        private Queue<Cell> queue;
        private int[,] dir = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
      
        public Labyrinth(string[,] matrix)
        {
            this.matrix = matrix;
            this.queue = new Queue<Cell>();
        }

        public void FindPathsQ(Cell cell)
        {
            this.queue.Enqueue(cell);

            while (this.queue.Count > 0)
            {
                Cell currentCell = this.queue.Dequeue();
                int row = currentCell.Row;
                int col = currentCell.Col;
                int dist = currentCell.Distance;
                matrix[row, col] = dist.ToString();

                for (int i = 0; i < dir.GetLength(0); i++)
                {
                    var nextCell = new Cell(
                        row + dir[i, 0],
                        col + dir[i, 1],
                        dist + 1);

                    if (isValid(nextCell))
                    {
                        queue.Enqueue(nextCell);
                    }
                }
            }
        }

        private bool isValid(Cell nextCell)
        {
            return nextCell.Row < this.matrix.GetLength(0) && nextCell.Row >= 0 &&
                    nextCell.Col < this.matrix.GetLength(1) && nextCell.Col >= 0 &&
                    this.matrix[nextCell.Row, nextCell.Col] == "0";
        }

        public void PrintMatrix()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", this.matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public void MarkUnreachableCells(Cell startCell)
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (this.matrix[row, col] == "0")
                    {
                        this.matrix[row, col] = "u";
                    }
                }
            }
            this.matrix[startCell.Row, startCell.Col] = "*";
        }
    }
}
