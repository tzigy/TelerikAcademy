namespace HashTableTests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problems.HashTable;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void SetShouldWorkProperly()
        {
            var testHashTable = new HashTable<int, int>();
            testHashTable.Set(1, 1);
            Assert.AreEqual(1, testHashTable[1]);
        }

        [TestMethod]
        public void SetShouldReplaceTheExistingValueWithTheNewOneWhenKeyExists()
        {
            var testHashTable = new HashTable<int, int>();
            testHashTable.Set(1, 1);
            testHashTable.Set(1, 2);
            Assert.AreEqual(2, testHashTable[1]);
        }

        [TestMethod]
        public void IndexerShouldReturnTheValueOfThePassedKey()
        {
            var testHashTable = new HashTable<int, int>();
            testHashTable.Set(1, 1);
            Assert.AreEqual(1, testHashTable[1]);
        }

        [TestMethod]
        public void IndexerShouldReturnTheDefaultValueIfThePassedKeyIsNotFound()
        {
            var testHashTable = new HashTable<int, int>();
            Assert.AreEqual(0, testHashTable[1]);
        }

        [TestMethod]
        public void IndexerShouldSetThePassedValueToThePassedKey()
        {
            var testHashTable = new HashTable<int, int>();
            testHashTable.Set(1, 1);
            testHashTable[1] = 2;
            Assert.AreEqual(2, testHashTable[1]);
        }

        [TestMethod]
        public void CountOfTheHashTableShouldWorkProperly()
        {
            var testHashTable = new HashTable<int, int>();
            for (int i = 0; i < 100; i++)
            {
                testHashTable.Set(i, i * 2);
            }
            Assert.AreEqual(100, testHashTable.Count);
        }

        [TestMethod]
        public void HashTableShouldWorkProperlyWithCollectionValues()
        {
            var testHashTable = new HashTable<int, List<int>>();
            testHashTable.Set(1, new List<int> {1, 2, 3});

            Assert.AreEqual(3, testHashTable[1][2]);
        }

        [TestMethod]
        public void RemoveShouldReturnTrueIfTheKeyIsFoundAndRemovedFromTheHashTable()
        {
            var testHashTable = new HashTable<int, int>();
            testHashTable.Set(1, 1);
            var removed = testHashTable.Remove(1);
            Assert.AreEqual(true, removed);
        }

        [TestMethod]
        public void RemoveShouldReturnFalseIfTheKeyIsNotFound()
        {
            var testHashTable = new HashTable<int, int>();
            testHashTable.Set(1, 1);
            var removed = testHashTable.Remove(2);
            Assert.AreEqual(false, removed);
        }

        [TestMethod]
        public void ClearShouldEmptyTheHashTable()
        {
            var testHashTable = new HashTable<int, int>();
            testHashTable.Set(1, 1);
            testHashTable.Clear();
            Assert.AreEqual(0, testHashTable.Count);
        }

        [TestMethod]
        public void ForeachOfTheHashTableShouldWorkProperly()
        {
            var testHashTable = new HashTable<int, int>();
            for (int i = 0; i < 100; i++)
            {
                testHashTable.Set(i, i * 2);
            }
            var listOfKeys = new List<int>(100);
            foreach (var key in testHashTable)
            {
                listOfKeys.Add(key.Value);
            }

            Assert.AreEqual(100, listOfKeys.Count);
        }
    }
}
