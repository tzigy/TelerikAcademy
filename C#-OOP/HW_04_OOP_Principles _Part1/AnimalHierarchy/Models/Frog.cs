namespace AnimalHierarchy.Models
{
    using AnimalHierarchy.Interfaces;
    using System;
    class Frog : Animal, IAnimal, ISound
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {

        }
        public override void MakeSound()
        {
            Console.WriteLine("Qua qua!");
        }
    }
}
