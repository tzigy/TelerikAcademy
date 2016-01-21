namespace HashSetTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Problems.CustomHashSet;
    using Problems.HashTable;

    [TestClass]
    public class HashSetTests
    {
        [TestMethod]
        public void AddMethodShouldAddAnElementIfItDoesNotExistInTheSet()
        {
            var testSet = new CustomHashSet<int>();
            testSet.Add(3);

            Assert.IsTrue(testSet.Contains(3));
        }

        [TestMethod]
        public void AddMethodShouldReturnFalseIfItExistsInTheSet()
        {
            var testSet = new CustomHashSet<int>();
            testSet.Add(3);
            var isAdded = testSet.Add(3);
            Console.WriteLine(testSet.Count);

            Assert.IsFalse(isAdded);
        }

        [TestMethod]
        public void AddMethodShouldReturnTrueIfTheElementIsAdded()
        {
            var testSet = new CustomHashSet<int>();
            var isAdded = testSet.Add(3);

            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void ToStringShouldWorkProperly()
        {
            var testSet = new CustomHashSet<int>();
            testSet.Add(1);
            testSet.Add(2);
            testSet.Add(3);

            Assert.AreEqual("1, 2, 3", testSet.ToString());
        }

        [TestMethod]
        public void FindShouldReturnProperValue()
        {
            var testSet = new CustomHashSet<int> { 1, 2, 3 };
            var number = testSet.Find(2);

            Assert.AreEqual(2, number);
        }

        [TestMethod]
        public void ClearShouldEmptyTheSet()
        {
            var testSet = new CustomHashSet<int> { 1, 2, 3 };
            testSet.Clear();
            Assert.AreEqual(0, testSet.Count);
        }

        [TestMethod]
        public void RemoveShouldReturnTrueWhenValueIsFoundAndRemoved()
        {
            var testSet = new CustomHashSet<int> { 1, 2, 3 };
            bool isRemoved = testSet.Remove(2);
            Assert.AreEqual(2, testSet.Count);
            Assert.IsTrue(isRemoved);
        }

        [TestMethod]
        public void RemoveShouldReturnFalseWhenValueIsNotFound()
        {
            var testSet = new CustomHashSet<int> { 1, 2, 3 };
            bool isRemoved = testSet.Remove(5);
            Assert.IsFalse(isRemoved);
        }

        [TestMethod]
        public void UnionShouldWorkProperly()
        {
            var firstSet = new CustomHashSet<string> { "Perl", "Java", "C#", "SQL", "PHP" };
            var secondSet = new CustomHashSet<string> { "Oracle", "SQL", "MySQL" };
            var union = firstSet.UnionWith(secondSet);

            Assert.AreEqual(7, union.Count);
        }

        [TestMethod]
        public void IntersectShouldWorkProperly()
        {
            var firstSet = new CustomHashSet<string> { "Perl", "Java", "C#", "SQL", "PHP" };
            var secondSet = new CustomHashSet<string> { "Oracle", "SQL", "MySQL" };
            var union = firstSet.IntersectWith(secondSet);

            Assert.AreEqual("SQL", union.ToString());
        }
    }
}
