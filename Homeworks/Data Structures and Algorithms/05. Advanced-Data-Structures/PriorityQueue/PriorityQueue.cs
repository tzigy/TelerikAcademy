namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> items;

        public T Root
        {
            get
            {
                return items[0];
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public PriorityQueue()
        {
            this.items = new List<T>();
        }

        public void Enquene(T item)
        {
            // https://en.wikipedia.org/wiki/Heapsort

            this.items.Add(item);

            var i = this.items.Count - 1;

            while (i > 0)
            {
                if (true)
                {
                    int parentId = (i - 1) / 2;
                    if (this.items[i].CompareTo(this.items[parentId]) > 0)
                    {
                        T current = items[i];
                        items[i] = items[parentId];
                        items[parentId] = current;
                        i = parentId;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public T Dequene()
        {
            int i = this.items.Count - 1;
            T result = this.items[0];
            items[0] = items[i];
            this.items.RemoveAt(i);

            MaxHeapify(this.items, 0);

            return result;
        }

        private void MaxHeapify(List<T> items, int i)
        {
            var left = 2 * i + 1;
            var rigth = 2 * i + 2;
            var largest = i;

            if (left < items.Count && items[left].CompareTo(items[largest]) > 0)
            {
                largest = left;
            }

            if (rigth < items.Count && items[rigth].CompareTo(items[largest]) > 0)
            {
                largest = rigth;
            }

            if (largest != i)
            {
                T current = items[i];
                items[i] = items[largest];
                items[largest] = current;
                MaxHeapify(items, largest);
            }
        }
    }
}
