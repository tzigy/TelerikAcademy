namespace _02.CombinationNK
{
    using System;

    public class Program
    {
        private static int[] arr;
        private static int[] set;

        public static void Main()
        {
            // Write a recursive program for generating and printing all the combinations with duplicatesof k elements from n-element set. Example:
            // n = 3, k = 2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

            int k = 2;
            int n = 3;
            arr = new int[k];
            set = new int[n];
            for (int i = 0; i < set.Length; i++)
            {
                set[i] = i + 1;
            }
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
                Combination(index + 1, i);
            }
        }
    }
}
