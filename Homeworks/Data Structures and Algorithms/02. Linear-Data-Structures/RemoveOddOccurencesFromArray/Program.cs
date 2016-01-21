namespace RemoveOddOccurencesFromArray
{
	using System;
	using System.Linq;

	public class Program
	{
		public static void Main()
		{
			int[] numbers = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
			PrintArrayElements(numbers);
			numbers = RemoveOddOccurences(numbers);
			Console.Write(" ---> ");
			PrintArrayElements(numbers);
		}

		private static int[] RemoveOddOccurences(int[] numbers)
		{
			return numbers.Where(x => numbers.Count(y => y == x) % 2 == 0).ToArray();
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
