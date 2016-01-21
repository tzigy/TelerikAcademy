namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student : IComparable<Student>
    {
        private List<Course> courses;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} {1}", this.FirstName, this.LastName);

            return output.ToString();
        }

        public int CompareTo(Student other)
        {
            int result = this.LastName.CompareTo(other.LastName);

            if (result == 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            return result;
        }
    }
}