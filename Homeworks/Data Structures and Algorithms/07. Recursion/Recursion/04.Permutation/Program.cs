namespace _04.Permutation
{
    using System;

    public class Program
    {
        private static int[] arr;

        public static void Main()
        {
            // Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n.Example:
            // n = 3 → { 1, 2, 3}, { 1, 3, 2}, { 2, 1, 3}, { 2, 3, 1}, { 3, 1, 2},{ 3, 2, 1}

            int n = 3;
            arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            GetPermutations(0);
        }

        private static void GetPermutations(int index)
        {
            if (arr.Length == index)
            {
                Console.Write("({0}), ", string.Join(" ", arr));
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                if (i != index)
                {
                    Swap(ref arr[i], ref arr[index]);
                }

                GetPermutations(index + 1);

                if (i != index)
                {
                    Swap(ref arr[i], ref arr[index]);
                }

            }
        }

        private static void Swap(ref int v1, ref int v2)
        {
            var temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
