namespace AnimalHierarchy.Models
{    
    using System;
    using AnimalHierarchy.Interfaces;
    class Dog : Animal, IAnimal, ISound
    {
        public Dog(string name, int age, Gender gender)
            : base (name, age, gender)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Bau bau!");
        }

    }
}
