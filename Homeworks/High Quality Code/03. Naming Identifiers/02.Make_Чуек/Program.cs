namespace Person
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Person newPerson = new Person(25);
            Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}", newPerson.Name, newPerson.Age, newPerson.Gender);
        }
    }
}