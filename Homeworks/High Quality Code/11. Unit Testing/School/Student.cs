namespace School
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private const int MinStudentIdValue = 10000;
        private const int MaxStudentIdValue = 99999;

        private string name;
        private int studentId;

        public Student(string name, int studentId)
        {
            this.Name = name;
            this.StudentId = studentId;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student name cannot be null, empty string or white spaces!");
                }

                this.name = value;
            } 
        }

        public int StudentId 
        {
            get
            {
                return this.studentId;
            }

            set
            {
                if (value < MinStudentIdValue || MaxStudentIdValue < value)
                {
                    throw new ArgumentOutOfRangeException("Invalid student ID!");
                }

                this.studentId = value;
            }
        }

        public void AttendCourse(Course course)
        {
            if (course == null)
            {
                throw new InvalidOperationException("Invalid course! Course cannot be null!");
            }

            course.AddStudentToCourse(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new InvalidOperationException("Invalid course! Course cannot be null!");
            }

            course.RemoveStudentFromCourse(this);
        }
    }
}
