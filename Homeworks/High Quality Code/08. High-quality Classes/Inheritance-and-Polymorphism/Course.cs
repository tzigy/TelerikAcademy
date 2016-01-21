namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.teacherName = null;
            this.students = new List<string>();
        }

        public Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, IList<string> students)
            : this(name, teacherName)
        {            
            if (students != null)
            {
                foreach (var student in students)
                {
                    this.students.Add(student);
                }
            }
        }

        public string Name 
        { 
            get
            {
                return this.name;
            }

            set
            {
                ///TODO: implement validations
                this.name = value;
            } 
        }

        public string TeacherName 
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                ///TODO: implement validations
                this.teacherName = value;
            }
        }

        public IList<string> Students { get; set; }       

        public void AddStudents(params string[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                this.students.Add(students[i]);
            }
        }

        public string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name.ToString());
            result.Append(" { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }        
    }
}