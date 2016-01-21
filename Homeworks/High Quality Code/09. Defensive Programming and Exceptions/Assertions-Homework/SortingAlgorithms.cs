namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public class SortingAlgorithms
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(0 < arr.Length, "SelectionSort: Array cannot be empty!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            bool isSorted = AssertionsHelpingFunctions.IsSortedArray(arr);
            Debug.Assert(isSorted, "SelectionSort does not work correctly. Array is not sorted!");
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(0 < arr.Length, "FindMinElementIndex: Array cannot be empty!");
            Debug.Assert(0 <= startIndex && startIndex < arr.Length - 1, "FindMinElementIndex: Start index not in range!");
            Debug.Assert(0 < endIndex && endIndex < arr.Length, "FindMinElementIndex: End index not in range!");
            Debug.Assert(startIndex < endIndex, "FindMinElementIndex: Start index cannot be bigger or equal than end index!");

            int minElementIndex = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            bool isMinElementIndex = AssertionsHelpingFunctions.IsMinElementIndex(arr, minElementIndex);
            Debug.Assert(isMinElementIndex, "FindMinElementIndex does not work correct. Invalid min element index!");

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
