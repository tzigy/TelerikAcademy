namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentReturnExpectedName()
        {
            string name = "Ivan Ivanov";
            int studentId = 10000;

            Student student = new Student(name, studentId);

            Assert.AreEqual(name, student.Name, string.Format("Student name should be {0}! It is {1}!", name, student.Name));
        }

        [TestMethod]
        public void StudentReturnExpectedStudentId()
        {
            string name = "Ivan Ivanov";
            int studentId = 10000;

            Student student = new Student(name, studentId);

            Assert.AreEqual(studentId, student.StudentId, string.Format("Student ID should be {0}! It is {1}!", studentId, student.StudentId));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfStudentNameIsNullThrowArgumentNullException()
        {
            string name = null;
            int studentId = 10000;

            Student student = new Student(name, studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfStudentNameIsEmptyStringThrowArgumentNullException()
        {
            string name = string.Empty;
            int studentId = 10000;

            Student student = new Student(name, studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfStudentNameIsWhiteSpacesThrowArgumentNullException()
        {
            string name = "  ";
            int studentId = 10000;

            Student student = new Student(name, studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfStudentIdIsLessThanMinRequiredStudentIdThrowArgumentOutOfRangeException()
        {
            string name = "Ivan Ivanov";
            int studentId = 999;

            Student student = new Student(name, studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfStudentIdIsBiggerThanMaxRequiredStudentIdThrowArgumentOutOfRangeException()
        {
            string name = "Ivan Ivanov";
            int studentId = 100000;

            Student student = new Student(name, studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfCourseArgumentInAttendCourseMethodIsNullThrowInvalidOperationException()
        {
            string name = "Ivan Ivanov";
            int studentId = 10000;
            Course course = null;

            Student student = new Student(name, studentId);
            student.AttendCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfCourseArgumentInLeaveCourseMethodIsNullThrowInvalidOperationException()
        {
            string name = "Ivan Ivanov";
            int studentId = 10000;
            Course course = null;

            Student student = new Student(name, studentId);
            student.LeaveCourse(course);
        }     
    }
}