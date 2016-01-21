namespace Problems.CustomHashSet
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Problems.HashTable;

    public class CustomHashSet<T> : IHashSet<T>, IEnumerable<T>
    {
        private HashTable<int, T> values;
        private int count;

        //public CustomHashSet(HashTable<int, T> startingValues)
        //{
        //    this.values = startingValues;
        //}

        public CustomHashSet()
        {
            this.values = new HashTable<int, T>();
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

        public void Clear()
        {
            this.count = 0;
            this.values = new HashTable<int, T>();
        }

        public bool Contains(T item)
        {
            return this.values.Get(this.GetHashCode(item)) != null;
        }

        public bool Add(T value)
        {
            if (this.values.Get(this.GetHashCode(value)) != null && !this.values[this.GetHashCode(value)].Equals(default(T)))
            {
                return false;
            }

            int key = this.GetHashCode(value);
            this.values.Set(key, value);
            this.Count++;
            return true;
        }

        public T Find(T value)
        {
            int key = this.GetHashCode(value);
            return this.values[key];
        }

        public bool Remove(T value)
        {
            if (this.values.Get(this.GetHashCode(value)) != null && this.values[this.GetHashCode(value)].Equals(default(T)))
            {
                return false;
            }

            int key = this.GetHashCode(value);
            this.values.Remove(key);
            this.Count--;
            return true;
        }

        public IHashSet<T> IntersectWith(CustomHashSet<T> other)
        {
            var result = new CustomHashSet<T>();

            foreach (var item in this.values)
            {
                foreach (var otherItem in other.values)
                {
                    if (item.Key == otherItem.Key)
                    {
                        result.Add(item.Value);
                    }
                }
            }

            return result;
        }

        public IHashSet<T> UnionWith(CustomHashSet<T> other)
        {
            var result = new CustomHashSet<T>();

            foreach (var item in this.values)
            {
                result.Add(item.Value);
            }

            foreach (var item in other.values)
            {
                if (result.values.Get(item.Key) == null)
                {
                    result.Add(item.Value);
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.values)
            {
                yield return item.Value;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetHashCode(T value)
        {
            int hash = value.GetHashCode();

            if (hash < 0)
            {
                hash *= -1;
            }

            return hash;
        }
    }
}