namespace StackImplementationWithArray
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class Stack<T> : IEnumerable<T>
	{
		public const int InitialCapacity = 4;
		private T[] stackArray;		
		private int count;

		public Stack()
			: this(InitialCapacity)
		{
		}

		public Stack(int initialCapacity)
		{			
			this.stackArray = new T[initialCapacity];
			this.Count = 0;
		}

		public int Count { get; set; }

		public int CurrentCapacity { get; set; }

		public void Push(T item)
		{
			if (this.Count < this.GetcurrentArrayCapacity())
			{
				this.stackArray[this.Count] = item;
				this.Count++;
			}
			else
			{
				T[] extendedArray = new T[2 * this.GetcurrentArrayCapacity()];
				Array.Copy(this.stackArray, extendedArray, this.Count);
				extendedArray[this.Count] = item;				
				this.stackArray = extendedArray;
				this.Count++;
			}
		}

		public T Pop()
		{
			if (this.IsEmpty())
			{
				throw new ArgumentOutOfRangeException("No elements in the stack!");
			}

			this.Count--;
			T topItem = this.stackArray[this.Count];

			return topItem;
		}

		public bool IsEmpty()
		{
			return this.Count == 0;
		}

		private int GetcurrentArrayCapacity()
		{
			return this.stackArray.Length;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < this.Count; i++)
			{
				yield return this.stackArray[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}

