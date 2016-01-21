namespace BiDictionary
{
    using System;

    public class Program
    {
        public static void Main()
        {
            BiDictionary<int, int, string> biDict = new BiDictionary<int, int, string>();
            biDict.Add(1, 1, "First");
            biDict.Add(1, 2, "Second");
            biDict.Add(2, 1, "Third");
            Console.WriteLine();
        }
    }
}
