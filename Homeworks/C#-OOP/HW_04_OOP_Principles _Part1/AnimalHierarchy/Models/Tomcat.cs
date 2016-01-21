namespace AnimalHierarchy.Models
{    
    using System;
    using AnimalHierarchy.Interfaces;
    class Tomcat : Cat, IAnimal, ISound
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Male)
        {

        }
    }
}
