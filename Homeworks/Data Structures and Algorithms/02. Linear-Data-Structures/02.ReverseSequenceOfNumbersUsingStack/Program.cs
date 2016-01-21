namespace ReverseSequenceOfNumbersUsingStack
{
	using System;
	using System.Collections.Generic;
	using HelpingFunctions;

	/// <summary>
	/// Write a program that reads N integers from the console and reverses them using a stack.
	///	Use the Stack<int> class.
	/// </summary>
	public class Program
	{
		public static void Main()
		{
			Stack<int> numbers = new Stack<int>();
			numbers = InputParseFunctions.ParseInputToStackOfInteger();

			while (numbers.Count > 0)
			{
				Console.WriteLine(numbers.Pop());
			}

		}		
	}
}
