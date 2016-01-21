namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public class SearchingAlgorithms
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(0 < arr.Length, "BinarySearch<T>: Array cannot be empty!");
            Debug.Assert(value != null, "BinarySearch<T>: Searched value cannot be null!");

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(0 < arr.Length, "BinarySearch: Array cannot be empty!");
            Debug.Assert(value != null, "BinarySearch: Searched value cannot be null!");
            Debug.Assert(0 <= startIndex && startIndex < arr.Length, "BinarySearch: Start index not in range!");
            Debug.Assert(0 <= endIndex && endIndex < arr.Length, "BinarySearch: End index not in range!");
            Debug.Assert(startIndex <= endIndex, "BinarySearch: Start index cannot be bigger than end index!");

            bool isSortedArray = AssertionsHelpingFunctions.IsSortedArray(arr);
            Debug.Assert(isSortedArray, "BinarySearch cannot be apply on unsorted array!");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            bool hasValue = AssertionsHelpingFunctions.HasValue(arr, value);
            Debug.Assert(hasValue, "BinarySearch returns -1, although searched value exist!");
            // Searched value not found
            return -1;
        }
    }
}
