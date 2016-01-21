namespace StackImplementationWithArray
{
	using System;

	public class Program
	{
		public static void Main()
		{
			Stack<int> stack = new Stack<int>();
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
			stack.Push(4);
			stack.Push(5);
			stack.Push(6);
			stack.Push(7);
			stack.Push(8);
			stack.Push(9);
			stack.Pop(); 
			stack.Push(10);

			foreach (var item in stack)
			{
				Console.Write("{0} ", item);
			}
			Console.WriteLine();
		}
	}
}
