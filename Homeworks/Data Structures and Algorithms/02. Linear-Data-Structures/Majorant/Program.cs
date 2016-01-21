namespace Majorant
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class Program
	{
		public static void Main()
		{
			int[] input = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
			List<int> numbers = new List<int>(input);

			if (IsMajorant(numbers))
			{
				Console.WriteLine("The majorant is: {0}", FindMajorant(numbers));
			}
			else
			{
				Console.WriteLine("The is no Majorant!");
			}			
		}

		private static int FindMajorant(List<int> numbers)
		{
			return numbers.GroupBy(item => item).First(x => x.Count() >= ((numbers.Count / 2) + 1)).Key;			
		}

		private static bool IsMajorant(List<int> numbers)
		{
			return numbers.Exists(x => (numbers.Count(y => y == x)) >= ((numbers.Count / 2) + 1));
		}
    }
}
