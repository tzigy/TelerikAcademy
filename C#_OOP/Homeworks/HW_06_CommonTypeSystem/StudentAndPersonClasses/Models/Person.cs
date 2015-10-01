namespace StudentAndPersonClasses.Models
{
    using System;
    using System.Text;
    class Person
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int? age;

        public Person(string fullName)
        {
            this.FullName = fullName;
        }
        public Person(string fullName, int age)
            : this(fullName)
        {
            this.Age = age;
        }

        public Person(string firstName, string middleName, string lastName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }
        public Person(string firstName, string middleName, string lastName, int age)
            : this(firstName, middleName, lastName)
        {
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "First name cannot be null, empty string or sequence of white spaces!");
                }
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Middle name cannot be null, empty string or sequence of white spaces!");
                }
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Last name cannot be null, empty string or sequence of white spaces!");
                }
                this.lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                StringBuilder fullName = new StringBuilder();
                fullName.AppendFormat("{0} {1} {2}",
                    this.FirstName,
                    this.MiddleName,
                    this.LastName);
                return fullName.ToString();
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Full name cannot be null, empty string or sequence of white spaces!");
                }
                string[] nameArray = value.Trim().Split(' ');
                if (nameArray.Length != 3)
                {
                    throw new ArgumentException("Full name should have first name, middle name and last name!");
                }
                this.FirstName = nameArray[0];
                this.MiddleName = nameArray[1];
                this.LastName = nameArray[2];
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Age cannot be negative number!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Name: {0}, Age: {1}",
                this.FullName,
                (this.Age == null ? "<unknown>" : this.Age.ToString()));

            return output.ToString();
        }

    }
}
