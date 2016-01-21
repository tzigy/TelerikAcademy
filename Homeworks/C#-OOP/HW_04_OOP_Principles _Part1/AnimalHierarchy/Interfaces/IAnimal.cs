namespace AnimalHierarchy.Interfaces
{    
    using System;
    using AnimalHierarchy.Models;
    public interface IAnimal
    {
        string Name {get;}
        int Age { get; }
        Gender Gender { get; }

    }
}
