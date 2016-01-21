using System;
using System.Text;

public class TextToNumber
{
    public const int MinModuleNumber = 2000;
    public const int MaxModuleNumber = 10000;
    public static char[] Alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',	'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
    public static void Main()
    {
        int moduleNumber = GetModuleNumber();
        StringBuilder text = GetInputText();
        long result = ParseTextToNumber(moduleNumber, text);

        Console.WriteLine(result);
    }

    private static long ParseTextToNumber(int moduleNumber, StringBuilder text) 
    {
        long result = 0;
        for (int i = 0; i < text.Length; i++)
        {            
            if (text[i] == '@')
            {
                break;
            } 
            else if (Char.IsNumber(text[i]))
            {
                result *= (int)Char.GetNumericValue(text[i]);
            }

            else if (Char.IsLetter(text[i]))
            {                
                int charValue = Array.IndexOf(Alphabet, text[i]);
                result += charValue;
            }
            else 
            {
                result = result % moduleNumber;
            }
        }

        return result;
    }   

    private static string GetInputData()
    {
        string input = Console.ReadLine();

        return input;
    }

    private static int GetModuleNumber()
    {
        int number = int.Parse(GetInputData());

        if (!IsIntInRange(number, MinModuleNumber, MaxModuleNumber))
        {
            throw new ArgumentOutOfRangeException("Invalid module number!");
        }

        return number;
    }

    private static StringBuilder GetInputText()
    {
        StringBuilder inputText = new StringBuilder(GetInputData().ToLower());

        if (100000 < inputText.Length)
        {
            throw new ArgumentOutOfRangeException("Input text is too long!");
        }

        return inputText;
    }

    private static bool IsIntInRange(int value, int minValue, int maxValue)
    {
        bool result = minValue <= value && value <= maxValue;

        return result;
    }
}