namespace PriorityQueue
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            //Implement a class PriorityQueue<T> based on the data structure "binary heap".

            PriorityQueue<Person> people = new PriorityQueue<Person>();
            people.Enquene(new Person("Doncho", 28));
            people.Enquene(new Person("Niki", 27));
            people.Enquene(new Person("Ivo", 29));
            people.Enquene(new Person("Asya", 24));
            people.Enquene(new Person("Ivo1", 35));
            people.Enquene(new Person("Asya1", 22));
            people.Enquene(new Person("Pesho", int.MinValue));

            Console.WriteLine("The root: {0}", people.Root);

            while (people.Count > 0)
            {
                Console.WriteLine(people.Dequene());
            }
        }
    }
}
