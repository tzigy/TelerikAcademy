using System;

public class ExamExpensesCalculator
{
    public const int MinNumberOfStudents = 1;
    public const int MaxNumberOfStudents = 10000;
    public const int MinSheetsPerStudent = 1;
    public const int MaxSheetsPerStudent = 500;
    public const double MinPriceOfRealm = 0.01;
    public const double MaxPriceOfRealm = 100;
    public const int SheetsInRealm = 500;

    public static void Main()
    {
        double expenses = CalculateExpenses();

        Console.WriteLine("{0:F2}", expenses);
    }

    private static double CalculateExpenses()
    {
        int numbersOfStudents = GetNumberOfStudents();
        int sheetPerStudent = GetNumberOfSheedsPerStudents();
        double pricePerRealm = GetPricePerRealm();
        double pricePerSheet = pricePerRealm / ((double)SheetsInRealm);
        double expenses = (numbersOfStudents * sheetPerStudent) * pricePerSheet;

        return expenses;
    }

    private static double GetInputFromConsole()
    {
        double input = double.Parse(Console.ReadLine());
  
        return input;
    }

    private static int GetNumberOfStudents()
    {
        int numberOfStudents = (int)GetInputFromConsole();
        if (!IsIntInRange(numberOfStudents, MinNumberOfStudents, MaxNumberOfStudents))
        {
            throw new ArgumentOutOfRangeException("Invalid number of students");
        }

        return numberOfStudents;
    }

    private static int GetNumberOfSheedsPerStudents()
    {
        int sheetsPerStudents = (int)GetInputFromConsole();
        if (!IsIntInRange(sheetsPerStudents, MinSheetsPerStudent, MaxSheetsPerStudent))
        {
            throw new ArgumentOutOfRangeException("Invalid number of sheets per students");
        }

        return sheetsPerStudents;
    }

    private static double GetPricePerRealm()
    {
        double pricePerRealm = GetInputFromConsole();

        if (pricePerRealm < MinPriceOfRealm || MaxPriceOfRealm < pricePerRealm)
        {
            throw new ArgumentOutOfRangeException("Invalid price for realm");
        }

        return pricePerRealm;
    }

    private static bool IsIntInRange(int value, int minValue, int maxValue)
    {
        bool result = minValue <= value && value <= maxValue;

        return result;
    }    
}