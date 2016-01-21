namespace Person
{
   public class Person
    {
        public Person(int age)
        {
            this.Age = age;
            if (age % 2 == 0)
            {
                this.Name = "Pesho";
                this.Gender = Gender.male;
            }
            else
            {
                this.Name = "Jane";
                this.Gender = Gender.female;
            }
        }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
