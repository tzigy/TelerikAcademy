namespace _11.RecursionRep
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Write a program to generate all permutations with repetitionsof given multi - set.
            // Example: the multi-set { 1, 3, 5, 5}

            int[] set = new int[] { 1, 3, 5, 5 };

            Array.Sort(set);
            PermuteRep(set, 0, set.Length);
        }

        private static void PermuteRep(int[] set, int start, int length)
        {
            Console.WriteLine("({0})", string.Join(" ", set));

            if (start < length)
            {
                for (int i = length - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        if (set[i] != set[j])
                        {
                            Swap(ref set[i], ref set[j]);
                            PermuteRep(set, i + 1, length);
                        }
                    }

                    var tmp = set[i];
                    for (int k = i; k < length - 1;)
                    {
                        set[k] = set[++k];
                    }

                    set[length - 1] = tmp;
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
