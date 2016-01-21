namespace LinkedListDataStructure
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class LinkedList<T> : IEnumerable<T>
	{
		public LinkedList()
			: this(null)
		{
			
		}

		public LinkedList(ListItem<T> firstItem)
		{
			this.FirstItem = firstItem;
		}

		public ListItem<T> FirstItem { get; set; }

		public IEnumerator<T> GetEnumerator()
		{
			var listItem = this.FirstItem;
			while (listItem != null)
			{
				yield return listItem.Value;
				listItem = listItem.NextItem;
			}
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
