using System;

namespace FastPower
{
    class Program
    {
        const int MOD = 1000000007;

        static long PowMod(long a, long p)
        {
            if (p == 0)
            {
                return 1;
            }

            if (p % 2 == 1)
            {
                return PowMod(a, p - 1) * a % MOD;
            }

            a = PowMod(a, p / 2);

            return a * a % MOD;

        }

        static void Main()
        {
            Console.WriteLine(PowMod(124,123456));
        }
    }
}
