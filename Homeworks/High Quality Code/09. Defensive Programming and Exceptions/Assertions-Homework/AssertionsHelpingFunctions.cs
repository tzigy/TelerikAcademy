namespace Assertions_Homework
{
    using System;

    public static class AssertionsHelpingFunctions
    {
        public static bool IsSortedArray<T>(T[] arr) where T : IComparable<T>
        {                          
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(arr[i - 1]) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsMinElementIndex<T>(T[] arr, int minElementIndex) where T : IComparable<T>
        {
            T minElement = arr[minElementIndex];
            for (int i = 0; i < arr.Length; i++)
            {
                if (minElementIndex == i)
                {
                    continue;
                }

                if (arr[i].CompareTo(minElement) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasValue<T>(T[] arr, T value) where T : IComparable<T>
        {
            bool result = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(value) == 0)
                {
                    result = true;
                }    
            }

            return result;
        }
    }    
 }

