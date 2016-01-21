#pragma warning disable 1570
namespace Problems.HashTable
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of <see cref="IDictionary"/> interface
    /// using a hash table. Collisions are resolved by chaining.
    /// </summary>
    /// <typeparam name="TKey">Type of the keys. Keys are required
    /// to correctly implement Equals() and GetHashCode()
    /// </typeparam>
    /// <typeparam name="TValue">Type of the values</typeparam>
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>,
        IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const int DefaultCapacity = 16;
        private const float DefaultLoadFactor = 0.75f;
        private List<KeyValuePair<TKey, TValue>>[] table;
        private readonly float loadFactor;
        private int threshold;
        private int size;
        private readonly int initialCapacity;

        /// <summary>Creates an empty hash table with the
        /// default capacity and load factor</summary>
        public HashTable()
            : this(DefaultCapacity, DefaultLoadFactor)
        {
        }

        /// <summary>Creates an empty hash table with given
        /// capacity and load factor</summary>
        public HashTable(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.table = new List<KeyValuePair<TKey, TValue>>[capacity];
            this.loadFactor = loadFactor;
            this.threshold = (int)(capacity * this.loadFactor);
        }

        /// <summary>Finds the chain of elements corresponding
        /// internally to given key (by its hash code)</summary>
        /// <param name="key">The chain of elements to be found</param>
        /// <param name="createIfMissing">creates an empty list
        /// of elements if the chain still does not exist</param>
        /// <returns>a list of elements in the chain or null</returns>
        private List<KeyValuePair<TKey, TValue>> FindChain(
            TKey key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF; // clear the negative bit
            index = index % this.table.Length;
            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<TKey, TValue>>();
            }
            return this.table[index];
        }

        /// <summary>Finds the value assigned to given key
        /// (works extremely fast)</summary>
        /// <returns>the value found or null when not found</returns>
        public TValue Get(TKey key)
        {
            List<KeyValuePair<TKey, TValue>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                foreach (KeyValuePair<TKey, TValue> entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            return default(TValue);
        }

        /// <summary>Assigns a value to certain key. If the key
        /// exists, its value is replaced. If the key does not
        /// exist, it is first created. Works very fast</summary>
        /// <returns>the old (replaced) value or null</returns>
        public TValue Set(TKey key, TValue value)
        {
            if (this.size >= this.threshold)
            {
                this.Expand();
            }

            List<KeyValuePair<TKey, TValue>> chain = this.FindChain(key, true);
            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<TKey, TValue> entry = chain[i];
                if (entry.Key.Equals(key))
                {
                    // Key found -> replace its value with the new value
                    KeyValuePair<TKey, TValue> newEntry =
                        new KeyValuePair<TKey, TValue>(key, value);
                    chain[i] = newEntry;
                    return entry.Value;
                }
            }
            chain.Add(new KeyValuePair<TKey, TValue>(key, value));
            this.size++;

            return default(TValue);
        }

        /// <summary>Gets / sets the value by given key. Get returns
        /// null when the key is not found. Set replaces the existing
        /// value or creates a new key-value pair if the key does not
        /// exist. Works very fast</summary>
        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.Set(key, value);
            }
        }

        /// <summary>Removes a key-value pair specified
        /// by certain key from the hash table.</summary>
        /// <returns>true if the pair was found removed
        /// or false if the key was not found</returns>
        public bool Remove(TKey key)
        {
            List<KeyValuePair<TKey, TValue>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    KeyValuePair<TKey, TValue> entry = chain[i];
                    if (entry.Key.Equals(key))
                    {
                        // Key found -> remove it
                        chain.RemoveAt(i);
                        this.size--;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>Returns the number of key-value pairs
        /// in the hash table (its size)</summary>
        public int Count
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>Clears all ements of the hash table</summary>
        public void Clear()
        {
            this.table =
                new List<KeyValuePair<TKey, TValue>>[this.initialCapacity];
            this.size = 0;
        }

        /// <summary>Expands the underlying hash-table. Creates 2
        /// times bigger table and transfers the old elements
        /// into it. This is a slow (linear) operation</summary>
        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;
            List<KeyValuePair<TKey, TValue>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<TKey, TValue>>[newCapacity];
            this.threshold = (int)(newCapacity * this.loadFactor);
            foreach (List<KeyValuePair<TKey, TValue>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<TKey, TValue> keyValuePair in oldChain)
                    {
                        List<KeyValuePair<TKey, TValue>> chain = this.FindChain(keyValuePair.Key, true);
                        chain.Add(keyValuePair);
                    }
                }
            }
        }

        /// <summary>Implements the IEnumerable<KeyValuePair<K, V>>
        /// to allow iterating over the key-value pairs in the hash
        /// table in foreach-loops</summary>
        IEnumerator<KeyValuePair<TKey, TValue>>
            IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            foreach (List<KeyValuePair<TKey, TValue>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<TKey, TValue> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        /// <summary>Implements IEnumerable (non-generic)
        /// as part of IEnumerable<KeyValuePair<K, V>></summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).
                GetEnumerator();
        }
    }
}