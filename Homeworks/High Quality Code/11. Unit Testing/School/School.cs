namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private string name;
        private ICollection<Student> studentsInSchool;
        private ICollection<Course> coursesInSchol;

        public School(string name)
        {
            this.Name = name;
            this.studentsInSchool = new List<Student>();
            this.coursesInSchol = new List<Course>();
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
                    throw new ArgumentNullException("School name cannot ne null, empty string or white spaces!");
                }

                this.name = value;
            }
        }

        public ICollection<Student> StudentsInSchool 
        {
            get
            {
                return this.studentsInSchool;
            } 
        }

        public ICollection<Course> CoursesInSchool 
        {
            get
            {
                return this.coursesInSchol;
            }            
        }

        public void AddStudentToSchool(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Invalid student argument! It cannot be added to school!");
            }

            if (this.StudentsInSchool.Contains(student))
            {
                throw new InvalidOperationException("Student already exist in the school!");
            }

            this.StudentsInSchool.Add(student);
        }

        public void RemoveStudentFromSchool(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Invalid student argument! It cannot be removed from school!");
            }

            if (!this.StudentsInSchool.Contains(student))
            {
                throw new InvalidOperationException("Student cannot be romoved from school! No such student in school!");
            }

            this.StudentsInSchool.Remove(student);
        }

        public void AddCourseToSchool(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Invalid course argument! It cannot be added to school!");
            }

            if (this.CoursesInSchool.Contains(course))
            {
                throw new InvalidOperationException("Course already exist in the school!");
            }

            this.CoursesInSchool.Add(course);
        }

        public void RemoveCourseFromSchool(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Invalid course argument! It cannot be removed from school!");
            }

            if (!this.CoursesInSchool.Contains(course))
            {
                throw new InvalidOperationException("Course cannot be removed from school! No such course!");
            }

            this.CoursesInSchool.Remove(course);
        }
    }
}
