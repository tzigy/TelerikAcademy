namespace _05.CombinationNKSet
{
    using System;

    public class Program
    {
        private static string[] arr;
        private static string[] set;
        private const int n = 3;

        public static void Main()
        {
            // Write a recursive program for generating and printing all ordered k - element subsets from n-element set(variations Vkn).
            // Example: n = 3, k = 2, set = { hi, a, b} → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

            int k = 2;
            arr = new string[k];
            set = new string[n] { "hi", "a", "b" };

            Combination(0);
        }

        private static void Combination(int index)
        {
            if (index == arr.Length)
            {
                Console.Write("({0}), ", string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                arr[index] = set[i];
                Combination(index + 1);
            }
        }
    }
}
