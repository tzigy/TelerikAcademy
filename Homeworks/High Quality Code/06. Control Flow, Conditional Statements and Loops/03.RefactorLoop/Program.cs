namespace RefactorLoop
{
    using System;

    public class Program
    {
        public const int ExpectedValue = 666;
        public const int Count = 100;
        public const int Min = 0;
        public const int Max = 1000;

        public static void Main()
        {            
            int[] testNumbersArray = new int[Count];
            Random randNum = new Random();

            for (int i = 0; i < testNumbersArray.Length; i++)
            {
                testNumbersArray[i] = randNum.Next(Min, Max);
            }
            
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(testNumbersArray[i]);
                
                if (i % 10 == 0)
                {
                    if (testNumbersArray[i] == ExpectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }                 
                }                
            }

            /// More code here            
        }
    }
}