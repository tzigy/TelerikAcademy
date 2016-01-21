namespace _06.SubsetOfStrings
{
    using System;

    public class Program
    {
        private static string[] arr;
        private static string[] set;

        public static void Main()
        {
            // Write a program for generating and printing all subsets of k strings from given set of strings.
            // Example: s = { test, rock, fun}, k = 2 → (test rock), (test fun), (rock fun)

            arr = new string[2];
            set = new string[3] { "test", "rock", "fun" };

            Combination(0, 0);
        }

        private static void Combination(int index, int start)
        {
            if (index == arr.Length)
            {
                Console.Write("({0}), ", string.Join(" ", arr));
                return;
            }
            for (int i = start; i < set.Length; i++)
            {
                arr[index] = set[i];
                Combination(index + 1, i + 1);
            }
        }
    }
}
