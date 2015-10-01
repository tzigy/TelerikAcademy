namespace StringBuilderExtention
{
    using System;
    using System.Text;
    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int lenght)
        {            
            if ((index + lenght) > str.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
                str = str.Remove(index + lenght, str.Length - (index + lenght));
                str = str.Remove(0, index);                

            return str;
        }
        static void Main()
        {
            StringBuilder newStr = new StringBuilder("0123456789");
            Console.WriteLine(newStr.Substring(1, 9).ToString());
        }
    }
}
