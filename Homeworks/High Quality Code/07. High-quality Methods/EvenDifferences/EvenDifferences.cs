using System;

public class EvenDifferences
{
    public static void Main()
    {
        string[] numbersSequence = GetInputNumberSequence();
        int sumOfAllEvenDifferences = CalculateAllEvenAbsoluteDifferences(numbersSequence);
        Console.WriteLine(sumOfAllEvenDifferences);
    }

    public static string[] GetInputNumberSequence()
    {
        string input = Console.ReadLine();
        string[] numberSequence = input.Split(' ');        
        return numberSequence;
    }

    public static int CalculateAbsoluteDifference(int a, int b)
    {
        int result = a < b ? (b - a) : (a - b);
        return result;
    }

    public static bool IsEvenNumber(int number)
    {
        bool result = (number % 2) == 0 ? true : false;
        return result;
    }

    public static int CalculateAllEvenAbsoluteDifferences(string[] numbers)
    {
        int firstNumber;
        int secondNumber;
        int currentAbsoluteDifference;
        int result = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            firstNumber = int.Parse(numbers[i]);
            secondNumber = int.Parse(numbers[i - 1]);
            currentAbsoluteDifference = CalculateAbsoluteDifference(firstNumber, secondNumber);
            Console.WriteLine(currentAbsoluteDifference);
            if (IsEvenNumber(currentAbsoluteDifference))
            {
                result += currentAbsoluteDifference;
                i += 1;
            }                        
        }

        return result;
    }
}