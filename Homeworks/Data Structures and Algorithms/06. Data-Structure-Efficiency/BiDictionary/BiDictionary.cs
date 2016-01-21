namespace BiDictionary
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<TKey1, TKey2, TValue>

    {
        private OrderedMultiDictionary<TKey1, TValue> dict1;
        private OrderedMultiDictionary<TKey2, TValue> dict2;

        public BiDictionary()
        {
            this.dict1 = new OrderedMultiDictionary<TKey1, TValue>(true);
            this.dict2 = new OrderedMultiDictionary<TKey2, TValue>(true);
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            this.dict1.Add(key1, value);
            this.dict2.Add(key2, value);
        }

        public ICollection<TValue> GetByFirstKey(TKey1 key)
        {
            return this.dict1.;
        }
    }
}
