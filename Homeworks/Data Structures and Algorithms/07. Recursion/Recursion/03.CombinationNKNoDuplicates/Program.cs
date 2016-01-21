namespace _03.CombinationNKNoDuplicates
{
    using System;

    public class Program
    {
        private static int[] arr;
        private static int[] set;

        public static void Main()
        {
            // Modify the previous program to skip duplicates:
            // n = 4, k = 2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

            int k = 2;
            int n = 4;
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
                Combination(index + 1, i + 1);
            }
        }
    }
}
