using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    private const int PrimeNumber = 23;
    private const int NonPrimeNumber = 33;

    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Array cannot be null or empty!");
        }

        if (startIndex < 0 || arr.Length < startIndex)
        {
            throw new ArgumentOutOfRangeException("Invalid start index! Start index out of range");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid count! Count cannot be negative number!");
        }

        if (arr.Length < startIndex + count)
        {
            throw new ArgumentOutOfRangeException("Start index + count must be less than array length!");
        }

        List<T> result = new List<T>();

        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null || str == string.Empty)
        {
            throw new ArgumentNullException(str, "Input string cannot be null or empty!");
        }

        if (str.Length < count)
        {
            throw new ArgumentOutOfRangeException("substring length", "Count cannot be bigger than string length!");
        }

        StringBuilder result = new StringBuilder();

        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        try
        {
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.Error.WriteLine(exception.Message);
        }

        Console.WriteLine(PrimeNumber + " is prime: " + CheckPrime(PrimeNumber));
        Console.WriteLine(NonPrimeNumber + " is prime: " + CheckPrime(NonPrimeNumber));

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}