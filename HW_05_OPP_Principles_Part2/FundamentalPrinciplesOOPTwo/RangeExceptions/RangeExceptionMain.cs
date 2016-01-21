/*Problem 3. Range Exceptions

Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It should hold error message and a range definition [start … end].
Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].*/

namespace RangeExceptions
{
    using System;

    class RangeExceptionMain
    {
        static void Main()
        {
            try
            {
                int number = 353;
                if (number < 1 || number > 100)
                {
                    throw new InvalidRangeException<int>("Invalid range input!", 1, 100);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                DateTime date = new DateTime(2015, 03, 31);
                if (date < new DateTime(1980, 01, 01) || date > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("Invalid date input!",
                        new DateTime(1977, 03, 11), new DateTime(1980, 05, 15));
                }

            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
