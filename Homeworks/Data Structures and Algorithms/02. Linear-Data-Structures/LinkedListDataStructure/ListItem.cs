namespace LinkedListDataStructure
{
	public class ListItem<T>
	{
		public ListItem(T value)
			: this(value, null)
		{
			//this.Value = value;			
		}

		public ListItem(T value, ListItem<T> nextItem)
		{
			this.Value = value;
			this.NextItem = nextItem;
		}

		public T Value { get; set; }
		public ListItem<T> NextItem { get; set; }

		public override string ToString()
		{
			return this.Value.ToString();
		}
	}
}
