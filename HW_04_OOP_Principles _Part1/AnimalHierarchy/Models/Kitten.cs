namespace AnimalHierarchy.Models
{    
    using System;
    using AnimalHierarchy.Interfaces;
    class Kitten : Cat, IAnimal, ISound
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.Female)
        {

        }
    }
}
