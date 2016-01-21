namespace AnimalHierarchy.Models
{    
    using System;
    using AnimalHierarchy.Interfaces;
    public abstract class Cat : Animal, IAnimal, ISound
    {
        protected Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Mau mau!");
        }
    }
}
