namespace School.Tests
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseReturnExpectedName()
        {
            string name = "Hight Quality Code";

            Course course = new Course(name);

            Assert.AreEqual(name, course.Name, string.Format("Course name should be {0}! It is {1}", name, course.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfCourseNameIsNullThrowArgumentNullException()
        {
            string name = null;            

            Course course = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfCourseNameIsEmptyStringThrowArgumentNullException()
        {
            string name = string.Empty;

            Course course = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfCourseNameIsWhiteSpacesThrowArgumentNullException()
        {
            string name = " ";

            Course course = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfTryToAddNullStudentToCourseThrowArgumentNullException()
        {
            string name = "Hight Quality Code";
            Student student = null;

            Course course = new Course(name);
            course.AddStudentToCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfTryToAddExistingStudentToCourseThrowInvalidOperationException()
        {
            string courseName = "Hight Quality Code";
            string studentName = "Ivan Ivanov";
            int studentId = 10000;
 
            Course course = new Course(courseName);
            Student student = new Student(studentName, studentId);

            course.AddStudentToCourse(student);
            course.AddStudentToCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfStudentsListIsFullThrowArgumentOutOfRangeException()
        {
            string courseName = "Hight Quality Code";
            string studentName = "Ivan Ivanov";
            int studentId = 10000;

            Course course = new Course(courseName);

            for (int i = 0; i <= 30; i++)
            {
                Student student = new Student(studentName + i, studentId + i);
                course.AddStudentToCourse(student);
            }            
        }

        [TestMethod]
        public void StudentShouldBeAddetInCourseList()
        {
            string courseName = "Hight Quality Code";
            string studentName = "Ivan Ivanov";
            int studentId = 10000;

            Course course = new Course(courseName);
            Student student = new Student(studentName, studentId);
            course.AddStudentToCourse(student);

            Assert.AreSame(student, course.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfTryToRemoveNullStudentToCourseThrowArgumentNullException()
        {
            string name = "Hight Quality Code";
            Student student = null;

            Course course = new Course(name);
            course.RemoveStudentFromCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfTryToRemoveNotExistingStudentToCourseThrowInvalidOperationException()
        {
            string courseName = "Hight Quality Code";
            string studentName = "Ivan Ivanov";
            int studentId = 10000;

            Course course = new Course(courseName);
            Student student = new Student(studentName, studentId);

            course.RemoveStudentFromCourse(student);
        }
       
        [TestMethod]
        public void StudentShouldBeRemovedInCourseList()
        {
            string courseName = "Hight Quality Code";
            string studentName = "Ivan Ivanov";
            int studentId = 10000;

            Course course = new Course(courseName);
            Student student = new Student(studentName, studentId);
            course.AddStudentToCourse(student);
            course.RemoveStudentFromCourse(student);

            Assert.AreEqual(0, course.Students.Count);
        }
    }
}
