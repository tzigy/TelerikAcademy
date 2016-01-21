namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxNumberOfStudentsInCourse = 30;

        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name 
        { 
            get
            {
                return this.name;
            } 

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be null, empty string or white spaces!");
                }

                this.name = value;
            } 
        }

        public ICollection<Student> Students 
        {
            get
            {
                return this.students;
            }           
        }

        public void AddStudentToCourse(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Invalid student! Null cannot be added!");
            }

            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Student is already in this course!");
            }

            if (this.Students.Count == MaxNumberOfStudentsInCourse)
            {
                throw new ArgumentOutOfRangeException("Course is full! Cannot add student!");
            }

            this.Students.Add(student);
        }

        public void RemoveStudentFromCourse(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Invalid student! Argument is null!");
            }

            if (!this.Students.Contains(student))
            {
                throw new InvalidOperationException("Student doesnot exist in this course!");     
            }

            this.Students.Remove(student);
        }
    }
}
