namespace Fibonacci
{
    using System;

    public class Program
    {
        const int MOD = 1000000007;
        private static int[] memo;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            memo = new int[n + 1];
            Console.WriteLine(Fibonacci(n));

        }

        public static int Fibonacci(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            int number = Fibonacci(n - 1) + Fibonacci(n - 2);
            number %= MOD;
            memo[n] = number;
            return number;
        }
    }
}
