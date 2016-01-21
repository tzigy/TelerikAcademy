namespace SortIntegerUsingList
{
	using System;
	using System.Collections.Generic;
	using HelpingFunctions;
	using System.Text;
	using System.Linq;

	public class Program
	{
		public static void Main()
		{
			List<int> numbers = new List<int>();
			numbers = InputParseFunctions.ParseInputToListOfIntegers();

			numbers = numbers.OrderBy(x => x).ToList();

			PrintNumbersInList(numbers);
		}

		private static void PrintNumbersInList(List<int> numbers)
		{
			StringBuilder output = new StringBuilder();

			foreach(var number in numbers)
			{
				output.AppendFormat("{0}, ", number);
			}

			string outputToString = output.ToString().Substring(0, output.Length - 2);

			Console.WriteLine(outputToString);
		}
	}
}
