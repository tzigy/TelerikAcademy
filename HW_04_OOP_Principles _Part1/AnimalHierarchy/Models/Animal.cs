namespace AnimalHierarchy.Models
{    
    using System;
    using AnimalHierarchy.Interfaces;
    public abstract class Animal : IAnimal, ISound
    {
        private string name;
        private int age;
        private Gender gender;

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Animal name cannot be null, empty string or white spaces!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Animal age cannot be negative!");
                }
                this.age = value;
            }
        }

        public Gender Gender { get; set; }


        public virtual void MakeSound()
        {
            Console.WriteLine("No sound for Animal!");
        }
    }
}
