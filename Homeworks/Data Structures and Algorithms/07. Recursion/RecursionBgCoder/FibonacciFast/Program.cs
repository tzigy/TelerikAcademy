namespace FibonacciFast
{
    using System;

    public class Program
    {
        static Matrix PowMod(Matrix a, long p)
        {
            if (p == 1)
            {
                return a;
            }

            if (p % 2 == 1)
            {
                return new Matrix(PowMod(a, p - 1), a);
            }

            a = PowMod(a, p / 2);
            return new Matrix(a, a);
        }

        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            var a = new Matrix(1, 1, 1, 0);
            Console.WriteLine(PowMod(a, n).Table[0, 1]);
        }
    }
}
