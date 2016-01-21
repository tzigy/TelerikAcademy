//Problem 6. Divisible by 7 and 3

//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.


using System;
using System.Linq;

class DivisibleBySevenAndThree
{
    static void Main()
    {

        int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 42, 63 };

        Console.WriteLine("Using Lambda Mehod!");
        var arrayLambda = intArray.Where(x => ((x % 3 == 0) && (x % 7 == 0)));
        //var arrayLambda = Array.FindAll(intArray, x => ((x % 3 == 0) && (x % 7 == 0)));
        foreach (var element in arrayLambda)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("Using LINQ Mehod!");
        var arrayLinq =
            from el in intArray
            where (el % 3 == 0) && (el % 7 == 0)
            select el;

        foreach (var element in arrayLinq)
        {
            Console.WriteLine(element);
        }



    }
}

