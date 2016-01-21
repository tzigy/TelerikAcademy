namespace BitArray
{
    using System;
    class Program
    {
        static void Main()
        {
            
            BitArray64 firstArray = new BitArray64(ulong.MaxValue);
            Console.WriteLine("Type ulong MaxValue as BitArray64:\n {0}", firstArray);

            BitArray64 secondArray = new BitArray64(8);
            Console.WriteLine("Type ulong number 8 as BitArray64:\n {0}", secondArray);

            secondArray[3] = 0;
            secondArray[4] = 1;
            Console.WriteLine("After setting the fouth bit to 0 and the fifth bit to 1:\n {0}", secondArray);

            Console.WriteLine();
            Console.WriteLine(firstArray.Equals(secondArray));
            Console.WriteLine(firstArray == secondArray);
            Console.WriteLine(firstArray != secondArray);

            Console.WriteLine();

            foreach (var bit in firstArray)
            {
                Console.Write(bit);
            }
            Console.WriteLine(); 
        }
    }
}
