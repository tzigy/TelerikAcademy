namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
            this.Lab = null;
        }

        public LocalCourse(string name, string teacherName)
            : base(name, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
            this.Lab = null;
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string laboratory)
            : base(name, teacherName, students)
        {
            this.Lab = laboratory;
        }

        public string Lab 
        {
            get
            {
                return this.lab;
            }

            set
            {
                ///TODO: Implemet validations
                this.lab = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
