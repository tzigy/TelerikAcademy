//Problem 1. StringBuilder.Substring

//Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.


namespace ExtensionMethods
{
    using System;
    using System.Text;
    static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int substringLenght)
        {
            ValidateStrBuilderSubstringInput(sb.Length, startIndex, substringLenght);

            StringBuilder substring = new StringBuilder(sb.ToString());

            substring = substring.Remove(startIndex + substringLenght, sb.Length - (startIndex + substringLenght));
            substring = substring.Remove(0, startIndex);

            return substring;
        }

        private static void ValidateStrBuilderSubstringInput(int sbLenght, int startIndex, int substringLenght)
        {
            if (sbLenght <= 0 || startIndex < 0 || substringLenght < 0)
            {
                throw new IndexOutOfRangeException("ValidateStrBuilderSubstringInput: Invalid input!");
            }

            if (sbLenght < (startIndex + substringLenght))
            {
                throw new ArgumentException("No such substring!");
            }
        }       
    }
}
