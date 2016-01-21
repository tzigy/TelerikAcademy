namespace AnimalHierarchy
{    
    using System;
    using System.Collections.Generic;
    using AnimalHierarchy.Interfaces;
    using AnimalHierarchy.Models;
    using System.Text;

    class AnimalHierarchyTest
    {
        static void Main()
        {
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(new Dog("Sharo", 3, Gender.Male));
            animals.Add(new Tomcat("Tom", 3));
            animals.Add(new Frog("Froggy", 2, Gender.Female));
            animals.Add(new Kitten("Kitty", 4));
            animals.Add(new Kitten("Liza", 6));
            animals.Add(new Kitten("Kate", 2));
            animals.Add(new Dog("Balkan", 8, Gender.Male));
            animals.Add(new Frog("Qua", 3, Gender.Male));
            animals.Add(new Dog("Laika", 5, Gender.Female));
            animals.Add(new Tomcat("Jack", 6));
            animals.Add(new Dog("Dgecky", 1, Gender.Male));

            Console.WriteLine(AvarageAgeOfAnimals(animals));

        }

        public static string AvarageAgeOfAnimals(List<IAnimal> animals)
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Dogs avarage age = {0:F2}\n", AvarageAge(animals.FindAll( x => x.GetType().Name == "Dog")));
            output.AppendFormat("Kittens avarage age = {0:F2}\n", AvarageAge(animals.FindAll(x => x.GetType().Name == "Kitten")));
            output.AppendFormat("Tomcats avarage age = {0:F2}\n", AvarageAge(animals.FindAll(x => x.GetType().Name == "Tomcat")));
            output.AppendFormat("Frogs avarage age = {0:F2}", AvarageAge(animals.FindAll(x => x.GetType().Name == "Frog")));

            return output.ToString();
        }


        public static double AvarageAge(List<IAnimal> animals)
        {
            double ageSum = 0;
            foreach (var animal in animals)
            {
                ageSum += animal.Age;
            }

            double numberOfAnimals = animals.Count;
            double avarageAge = ageSum / numberOfAnimals;

            return avarageAge;
        }
    }
}
