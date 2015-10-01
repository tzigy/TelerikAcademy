using System;
using System.Collections.Generic;
using System.Linq;

class LongestString
{
    static void Main()
    {
        string[] stringArray = { "Hello", "I", "am", "Pesho", "Peshev", "from", "Bulgaria", "Bye" };

       // var longestString = stringArray.OrderBy(x => x.Length).Last();       

        var longestString =
            from str in stringArray
            orderby str.Length
            select str;
        
            Console.WriteLine("The longest string is {0}!", longestString.Last());
        
    }
}

