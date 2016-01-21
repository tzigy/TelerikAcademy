namespace _01.NestedLoopsRecursion
{
    using System;

    public class Program
    {
        private static int[] arr;

        public static void Main()
        {
            // Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
            /*
                     1 1
            n=2  ->  1 2
                     2 1
                     2 2

                     1 1 1
                     1 1 2
                     1 1 3
                     1 2 1
            n=3  ->  ...
                     3 2 3
                     3 3 1
                     3 3 2
                     3 3 3
            */

            int num = 3;
            arr = new int[num];
            Combination(0);
        }

        private static void Combination(int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[index] = i + 1;
                Combination(index + 1);
            }
        }
    }
}
