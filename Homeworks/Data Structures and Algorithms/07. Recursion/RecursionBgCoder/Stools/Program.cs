namespace Stools
{
    using System;

    class Stool
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Stool(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    class Program
    {
        static Stool[] stools;
        static int n;
        static int[,,] memo;

        static int MaxHeight(int used, int top, int side)
        {
            if (memo[used, top, side] != 0)
            {
                return memo[used, top, side];
            }

            if (used == (1 << top))
            {
                if (side == 0)
                {
                    return stools[top].X; // 0 -> X is height
                }
                if (side == 1)
                {
                    return stools[top].Y; // 1 -> Y is height
                }
                return stools[top].Z;  // 2 -> Z is height
            }

            // 0 -> Y Z
            // 1 -> X Z
            // 2 -> X Y
            int SideX = (side == 0) ? stools[top].Y : stools[top].X;
            int SideY = (side == 2) ? stools[top].Y : stools[top].Z;
            int SideHeight = stools[top].X + stools[top].Y + stools[top].Z
                - SideX - SideY;

            int result = SideHeight;
            int fromStools = used ^ (1 << top);

            for (int i = 0; i < n; i++)
            {
                if (((fromStools >> i) & 1) == 1)
                {
                    // side of stools[i] == 0
                    if ((stools[i].Y >= SideX && stools[i].Z >= SideY)
                     || (stools[i].Y >= SideY && stools[i].Z >= SideX))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 0) + SideHeight);
                    }

                    if (stools[i].X == stools[i].Y &&
                        stools[i].X == stools[i].Z)
                    {
                        continue;
                    }

                    // side of stools[i] == 1
                    if ((stools[i].X >= SideX && stools[i].Z >= SideY)
                     || (stools[i].X >= SideY && stools[i].Z >= SideX))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 1) + SideHeight);
                    }

                    // side of stools[i] == 2
                    if ((stools[i].X >= SideX && stools[i].Y >= SideY)
                     || (stools[i].X >= SideY && stools[i].Y >= SideX))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 2) + SideHeight);
                    }
                }
            }
            memo[used, top, side] = result;
            return result;
        }

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            stools = new Stool[n];

            memo = new int[1 << n, n, 3];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                stools[i] = new Stool(
                    int.Parse(line[0]),
                    int.Parse(line[1]),
                    int.Parse(line[2])
                    );
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                result = Math.Max(result, MaxHeight((1 << n) - 1, i, 0));
                result = Math.Max(result, MaxHeight((1 << n) - 1, i, 1));
                result = Math.Max(result, MaxHeight((1 << n) - 1, i, 2));
            }

            Console.WriteLine(result);
        }
    }
}
