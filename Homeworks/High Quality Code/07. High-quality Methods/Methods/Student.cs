namespace Methods
{
    using System;

    internal class Student
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string otherInfo;

        public Student(string firstName, string lastName, string birthDate, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = DateTime.Parse(birthDate);
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                ///TODO: implement validations
                this.firstName = value;
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
                ///TODO: implement validations
                this.lastName = value;
            }
        }

        public DateTime BirthDate 
        {
            get
            {
                return this.birthDate;
            }

            private set
            {
                ///TODO: implement validations
                this.birthDate = value;
            } 
        }

        public string OtherInfo 
        {
            get
            {
                return this.otherInfo;
            }

            private set
            {
                ///TODO: implement validations
                this.otherInfo = value;
            } 
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlder = this.BirthDate > other.BirthDate;

            return isOlder;
        }
    }
}