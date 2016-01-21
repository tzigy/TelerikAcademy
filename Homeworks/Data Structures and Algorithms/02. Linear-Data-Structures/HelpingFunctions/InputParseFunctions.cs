namespace HelpingFunctions
{
	using System;
	using System.Collections.Generic;

	public static class InputParseFunctions
	{
		public static List<int> ParseInputToListOfIntegers()
		{
			Console.WriteLine("Enter an integer number: ");
			string input = Console.ReadLine();

			List<int> numbers = new List<int>();

			while (!String.IsNullOrEmpty(input))
			{
				numbers.Add(Int32.Parse(input));
				Console.WriteLine("Enter another integer number or ENTER for end: ");
				input = Console.ReadLine();
			}

			return numbers;
		}

		public static Stack<int> ParseInputToStackOfInteger()
		{
			Console.WriteLine("Enter an integer number: ");
			string input = Console.ReadLine();

			Stack<int> numbers = new Stack<int>();

			while (!String.IsNullOrEmpty(input))
			{
				numbers.Push(Int32.Parse(input));
				Console.WriteLine("Enter another integer number or ENTER for end: ");
				input = Console.ReadLine();
			}

			return numbers;
		}
	}
}
