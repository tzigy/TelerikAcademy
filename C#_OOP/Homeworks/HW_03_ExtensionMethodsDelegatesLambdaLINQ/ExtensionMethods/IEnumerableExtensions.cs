//Problem 2. IEnumerable extensions

//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;
   // using System.Linq;
    
    static class IEnumerableExtensions
    {      
        public static T Sum<T>(this IEnumerable<T> collection) where T : IComparable, IConvertible
        {          
            dynamic sumOfAllElements = default(T);

            foreach (T element in collection)
            {
              sumOfAllElements += element;
            }
            return sumOfAllElements;
        }

        public static T Product<T>(this IEnumerable<T> collection) where T : struct // Product of Strings is not allowed!
        {
            dynamic productOfAllElements = 1;

            foreach (T element in collection)
            {
                productOfAllElements *= element;
            }
            return productOfAllElements;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable, IConvertible
        {
            T minElement = default(T);
           // If I do not use LINQ, I need to take first an element from the collection and than to find the min one.
            foreach (T element in collection)
            {
                minElement = element;
            }            
           // T minElement = collection.First(); 
            foreach (T element in collection)
            {
                if (minElement.CompareTo(element) > 0)
                {
                    minElement = element;
                }
            }
            return minElement;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable, IConvertible
        {
            T maxElement = default(T);
            // If I do not use LINQ, I need to take first an element from the collection and than to find the min one.
            foreach (T element in collection)
            {
                maxElement = element;
            }
            // T minElement = collection.First(); 
            foreach (T element in collection)
            {
                if (maxElement.CompareTo(element) < 0)
                {
                    maxElement = element;
                }
            }
            return maxElement;
        }

        public static double Avarage<T>(this IEnumerable<T> collection) where T : struct
        {
            double sumOfAllElements = 0.0;
            int count = 0;

            foreach (var element in collection)
            {
                sumOfAllElements += (dynamic)element;
                count++;
            }
            return sumOfAllElements/count;
        }
    }
}
