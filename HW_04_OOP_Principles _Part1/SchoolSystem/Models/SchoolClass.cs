namespace SchoolSystem.Models
{
    using System;
    using SchoolSystem.Interfaces;
    using System.Collections.Generic;
    public class SchoolClass : ISchoolClass, IComment
    {
        private string classID;
        private ICollection<IStudent> students;
        private ICollection<ITeacher> teachers;
        private ICollection<string> comments;

        public SchoolClass(string classId)
        {
            this.ClassID = classId;
            this.students = new List<IStudent>();
            this.teachers = new List<ITeacher>();
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

        public ICollection<IStudent> Students 
        {
            get { return this.students; } 
        }
        public ICollection<ITeacher> Teachers 
        {
            get { return this.teachers; } 
        }

        public void AddStudent(IStudent student)
        {
            this.Students.Add(student);
        }

        public void AddTeacher(ITeacher teacher)
        {
            this.teachers.Add(teacher);
        }


        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
