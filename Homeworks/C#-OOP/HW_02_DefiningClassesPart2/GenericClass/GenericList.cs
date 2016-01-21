namespace GenericClass
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class GenericList<T> where T : IComparable
    {
        private const int INITIAL_LIST_CAPACITY = 4;
        private T[] arr;
        private int count;

        public GenericList()
            : this(INITIAL_LIST_CAPACITY)
        {
        }

        public GenericList(int initialCapacity)
        {
            this.arr = new T[initialCapacity];
            this.Count = 0;
        }

        
        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.arr.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if ((index > this.Count) || (index < 0))
                {
                    throw new IndexOutOfRangeException("Invalid index: " + index);
                }

                return arr[index];
            }
        }

        public void Add(T newElement)
        {
            Insert(this.Count, newElement);
        }

        public void Insert(int index, T newElement)
        {
            if ((index > this.Count) || (index < 0))
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            T[] extendedArr = arr;

            if (this.Count + 1 == this.Capacity)
            {
                extendedArr = new T[2 * this.Capacity];
            }

            Array.Copy(arr, extendedArr, index);
            this.Count++;
            Array.Copy(arr, index, extendedArr, index + 1, this.Count - index - 1);
            extendedArr[index] = newElement;
            arr = extendedArr;
            
        }


        public int IndexOf(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (element.CompareTo(arr[i]) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveAt(int index)
        {            
            if((index > this.Count) || (index < 0))
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            Array.Copy(arr, index, arr, index + 1, this.Count - index - 1);
            arr[this.Count - 1] = default(T);
            this.Count--;
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.arr[i] = default(T);
            }
        }

        public override string ToString()
        {
            StringBuilder printedString = new StringBuilder();
            printedString.Append(string.Format("The list has {0} elements: [", this.Count));
            for (int i = 0; i < this.Count; i++)
            {
                printedString.Append(string.Format("{0}, " , arr[i]));
            }
            printedString.Remove(printedString.Length - 2, 2);
            printedString.Append("]");
            return printedString.ToString();
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("No elements in the list!");
            }

            T minElement = this.arr[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (minElement.CompareTo(this.arr[i]) > 0)
                {
                    minElement = this.arr[i];
                }
            }
            return minElement;
        }

        public T Max() 
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("No elements in the list!");
            }

            T maxElement = this.arr[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (maxElement.CompareTo(this.arr[i]) < 0)
                {
                    maxElement = this.arr[i];
                }
            }
            return maxElement;
        }


 
    }

}

