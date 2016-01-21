namespace CalculateSumAndAvarageUsingList
{
	using System;
	using System.Collections.Generic;
	using HelpingFunctions;

	/// <summary>
	/// Write a program that reads from the console a sequence of positive integer numbers.
	///		- The sequence ends when empty line is entered.
	///		- Calculate and print the sum and average of the elements of the sequence.
	///		- Keep the sequence in List<int>.
	/// </summary>

	public class Program
	{
		public static void Main()
		{
			List<int> numbers = new List<int>();
			numbers = InputParseFunctions.ParseInputToListOfIntegers();

			int sum = CalculteSumOfNumbersInList(numbers);
			double avarage = CalculateAvarageOfNumbersinList(numbers);

			Console.WriteLine("The sum is {0}", sum);
			Console.WriteLine("The avarage is {0:F2}", avarage);
		}

		private static int CalculteSumOfNumbersInList(List<int> numbers)
		{
			int sum = 0;

			foreach (var number in numbers)
			{
				sum += number;
			}

			return sum;
		}

		private static double CalculateAvarageOfNumbersinList(List<int> numbers)
		{
			double avarage = (double)CalculteSumOfNumbersInList(numbers) / numbers.Count;

			return avarage;
		}
	}
}