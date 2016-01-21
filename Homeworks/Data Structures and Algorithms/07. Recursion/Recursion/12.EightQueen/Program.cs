namespace _12.EightQueen
{
    using System;

    public class Program
    {
        public static void Main()
        {
            EightQueen queen = new EightQueen(8);
            queen.GetSolution();
        }
    }

    public class EightQueen
    {
        public int Size { get; set; }

        public EightQueen(int size)
        {
            this.Size = size;
        }
        public void GetSolution()
        {
            int line = 0;
            int pos = -1;
            int count = 0;
            int[] positions = new int[this.Size];
            for (int m = 0; m < positions.Length; m++)
            {
                positions[m] = -1;
            }
                
            while (true)
            {
                for (pos = positions[line] + 1; pos < this.Size; pos++)
                {
                    int i = 0;
                    for (i = 0; i < line; i++)
                    {
                        int dis = line - i;
                        if (positions[i] == pos || positions[i] == pos + dis || positions[i] == pos - dis)
                            break;
                    }
                    if (i == line)
                    {
                        positions[line] = pos;
                        line++;
                        if (line == Size)
                        {
                            count++;
                            Console.WriteLine(count);
                            foreach (int item in positions)
                            {
                                for (int j = 0; j < Size; j++)
                                {
                                    if (j == item)
                                        Console.Write("Q ");
                                    else
                                        Console.Write("* ");
                                }
                                Console.WriteLine();
                            }
                            line--;
                        }
                        else
                            break;
                    }
                }
                if (pos == Size)
                {
                    if (line == 0)
                    {
                        Console.WriteLine("Over");
                        break;
                    }
                    else
                    {
                        positions[line] = -1;
                        line--;
                    }
                }
            }
        }
    }
}
