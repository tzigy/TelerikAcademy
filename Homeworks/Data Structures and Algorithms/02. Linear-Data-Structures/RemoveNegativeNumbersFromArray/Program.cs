namespace RemoveNegativeNumbersFromArray
{
	using System;
	using System.Linq;

	/// <summary>
	/// Write a program that removes from given sequence all negative numbers.
	/// </summary>
	public class Program
	{
		public static void Main()
		{
			int[] numbers = { 1, 7, -3, 5, -4, 9, -7 };
			PrintArrayElements(numbers);

			int[] nonNegativeNumbersArray = RemoveNegativeNumbersFromArray(numbers);
			Console.WriteLine("\nAfter removing negative numbers:");
			PrintArrayElements(nonNegativeNumbersArray);
			Console.WriteLine("\n-------------------------------");
		}

		private static int[] RemoveNegativeNumbersFromArray(int[] numbers)
		{
			int[] nonNegativeNumbersArray = numbers.Select(x => x)
											  .Where(y => y > 0)
											  .ToArray();

			return nonNegativeNumbersArray;
		}

		private static void PrintArrayElements(int[] array)
		{
			foreach (var item in array)
			{
				Console.Write("{0} ", item);
			}
		}
	}
}
