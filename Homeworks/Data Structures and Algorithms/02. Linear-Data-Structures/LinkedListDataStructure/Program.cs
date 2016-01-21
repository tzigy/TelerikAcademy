namespace LinkedListDataStructure
{
	using System;

	public class Program
	{
		public static void Main()
		{
			ListItem<int> firstListItem = new ListItem<int>(1);
			ListItem<int> secondListItem = new ListItem<int>(2);

			LinkedList<int> list = new LinkedList<int>(firstListItem);
						
			firstListItem.NextItem = secondListItem;

			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
	}
}
