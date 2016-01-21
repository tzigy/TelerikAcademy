namespace ExtensionMethods
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    class ExtensionMethodsTest
    {
        
        static void Main()
        {
            StringBuilder newStr = new StringBuilder("0123456789");
            Console.WriteLine("Using StringBuilder.Substring() -> {0}", newStr.Substring(1, 9).ToString());
            Console.WriteLine("Using String.Substring() -> {0}\n", newStr.ToString().Substring(1, 9));


            List<string> newStringList = new List<string>() { "Pesho", "Gosho", "Bulgaria", "Hello"};
            
            Console.WriteLine("List of strings: function SUM -> {0}", newStringList.Sum().ToString());
            Console.WriteLine("List of strings: function MIN -> {0}", newStringList.Min().ToString());
            Console.WriteLine("List of strings: function MAX -> {0}", newStringList.Max().ToString());

            List<int> newIntList = new List<int>() { 5, 4, 2, 9};

            Console.WriteLine("\nList of int: function SUM -> {0}", newIntList.Sum().ToString());
            Console.WriteLine("List of int: function PRODUCT -> {0}", newIntList.Product().ToString());
            Console.WriteLine("List of int: function MIN -> {0}", newIntList.Min().ToString());
            Console.WriteLine("List of int: function Max -> {0}", newIntList.Max().ToString());
            Console.WriteLine("List of int: function AVERAGE -> {0}", newIntList.Avarage().ToString());
            
        }
    }
}
