namespace FindsLongestSubsequence
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public static class Program
	{
		
		public static void Main()
		{
			int[] input = { 1, 1, 1, 3, 3, 3, 3, 5, 5, 5, 5, };
			List<int> numbers = new List<int>(input);
			PrintNumbersInList(numbers);
			List<int> longetstSubsequence = FindLongestSubsequence(numbers);
			Console.WriteLine("The longest subsequence ist:");
			PrintNumbersInList(longetstSubsequence);
		}

		private static List<int> FindLongestSubsequence(List<int> numbers)
		{
			if (numbers.Count < 0)
			{
				throw new ArgumentException("List cannot be empty!");
			}

			int maxCount = 1;
			List<int> longestSubsequenceList = new List<int>();
			longestSubsequenceList.Add(numbers[0]);

			int currentCount = 1;
			List<int> currentSubsequenceList = new List<int>();
			currentSubsequenceList.Add(numbers[0]);

			for (int i = 1; i < numbers.Count; i++)
			{
				if (numbers[i] == numbers[i - 1])
				{
					currentSubsequenceList.Add(numbers[i]);
					currentCount++;

					if ((i == numbers.Count - 1) && (maxCount < currentCount))
					{
						longestSubsequenceList.Clear();
						longestSubsequenceList = new List<int>(currentSubsequenceList);
					}
				}
				else
				{
					if (maxCount < currentCount)
					{
						longestSubsequenceList.Clear();
						longestSubsequenceList = new List<int>(currentSubsequenceList);
						maxCount = currentCount;
					}

					currentSubsequenceList.Clear();
					currentSubsequenceList.Add(numbers[i]);
					currentCount = 1;
				}
			}

			return longestSubsequenceList;
		}

		private static void PrintNumbersInList(List<int> numbers)
		{
			StringBuilder output = new StringBuilder();

			foreach (var number in numbers)
			{
				output.AppendFormat("{0}, ", number);
			}

			string outputToString = output.ToString().Substring(0, output.Length - 2);

			Console.WriteLine(outputToString);
		}		
	}
}
