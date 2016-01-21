namespace PriorityQueue
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }


        public int CompareTo(Person other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.Name, this.Age);
        }
    }
}
