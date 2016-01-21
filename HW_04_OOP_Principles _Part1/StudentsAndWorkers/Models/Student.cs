namespace StudentsAndWorkers.Models
{
    using System;
    using System.Text;
    class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade 
        {
            get { return this.grade; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "Student grade should be between 0 and 100 points!");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString().Trim());
            output.AppendFormat("; Student; Grade: {0}", this.Grade);
            return output.ToString();
        }
    }
}
