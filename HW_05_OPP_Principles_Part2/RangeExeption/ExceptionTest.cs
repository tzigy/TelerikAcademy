namespace RangeExeption
{
    using System;
    class ExceptionTest
    {
        static void IntegerTest(int start, int end, int inputNumber)
        {
            try
            {
                if (inputNumber < start || inputNumber > end)
                {
                    throw new InvalidRangeException<int>(start, end);
                }
                else
                {
                    Console.WriteLine("The number is in the range!");
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex);                
            }
        }

      
        static void DateTimeTest(DateTime start, DateTime end, DateTime inputDate)
        {
            try
            {
                if (inputDate < start || inputDate > end)
                {
                    throw new InvalidRangeException<DateTime>("Invalid input. The date is not in range!", start, end);
                }
                else
                {
                    Console.WriteLine("The date is in the range!");
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);                
                Console.WriteLine("The range is [{0} - {1}]", ex.Start, ex.End);
            }
        }

        static void Main(string[] args)
        {
            IntegerTest(1, 100, 123);
            DateTimeTest(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31), DateTime.Now);
        }

    }

}
