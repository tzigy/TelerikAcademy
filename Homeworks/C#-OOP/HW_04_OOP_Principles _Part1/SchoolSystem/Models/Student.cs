namespace SchoolSystem.Models
{
    using System;
    using SchoolSystem.Interfaces;    
    public class Student : People, IStudent, IComment
    {
        private string classID;        

        public Student(string name) 
            : base(name)
        {
 
        }

        public Student(string name, string classNumber)
            : this(name)
        {
            this.ClassID = classNumber;
        }

        public string ClassID 
        {
            get { return this.classID; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Class number cannot be null, empty string or white spaces!");
                }

                this.classID = value;
            }
        }
    }
}
