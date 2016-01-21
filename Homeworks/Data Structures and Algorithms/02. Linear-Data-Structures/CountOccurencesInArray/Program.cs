namespace CountOccurencesInArray
{
	using System;
	using System.Linq;

	public class Program
	{
		public static void Main()
		{
			int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
			PrintArrayElements(numbers);

			var groups = numbers.GroupBy(item => item).OrderBy(group => group.Key);

			foreach (var group in groups)
			{
				Console.WriteLine("{0} -> {1} times", group.Key, group.Count());
			}
		}

		private static void PrintArrayElements(int[] array)
		{			
			foreach (var item in array)
			{
				Console.Write("{0} ", item);
			}
			Console.WriteLine();
		}
	}
}
