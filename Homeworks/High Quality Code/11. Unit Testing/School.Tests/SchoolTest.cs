namespace School.Tests
{    
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolReturnExpectedName()
        {
            string name = "Telerik Academy";            

            School school = new School(name);

            Assert.AreEqual(name, school.Name, string.Format("Student name should be {0}! It is {1}!", name, school.Name));
        }        

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfSchoolNameIsNullThrowArgumentNullException()
        {
            string name = null;            

            School school = new School(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfSchoolNameIsEmptyStringThrowArgumentNullException()
        {
            string name = string.Empty;

            School school = new School(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfSchoolNameIsWhiteSpacesThrowArgumentNullException()
        {
            string name = "  ";

            School school = new School(name);
        }

        [TestMethod]
        public void StudentShouldBeAddetInSchool()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string studentName = "Ivan Ivanov";
            int studentId = 10000;
            Student student = new Student(studentName, studentId);

            school.AddStudentToSchool(student);
            Assert.AreSame(student, school.StudentsInSchool.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfTryToAddNullStudentToSchoolThrowArgumentNullException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            Student student = null;

            school.AddStudentToSchool(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfTryToAddExistingStudentToSchoolThrowInvalidOperationException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string studentName = "Ivan Ivanov";
            int studentId = 10000;
            Student student = new Student(studentName, studentId);

            school.AddStudentToSchool(student);
            school.AddStudentToSchool(student);
        }

        [TestMethod]
        public void CourseShouldBeAddetInSchool()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string courseName = "Hight Quality Code";
            Course course = new Course(courseName);
            school.AddCourseToSchool(course);
            Assert.AreSame(course, school.CoursesInSchool.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfTryToAddNullCourseToSchoolThrowArgumentNullException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            Course course = null;

            school.AddCourseToSchool(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfTryToAddExistingCourseToSchoolThrowInvalidOperationException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string courseName = "Hight Quality Code";
            Course course = new Course(courseName);

            school.AddCourseToSchool(course);
            school.AddCourseToSchool(course);
        }

        [TestMethod]
        public void StudentShouldBeRemovedFromSchool()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string studentName = "Ivan Ivanov";
            int studentId = 10000;
            Student student = new Student(studentName, studentId);

            school.AddStudentToSchool(student);
            school.RemoveStudentFromSchool(student);

            Assert.AreEqual(0, school.StudentsInSchool.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfTryToRemoveNullStudentFromSchoolThrowArgumentNullException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            Student student = null;

            school.RemoveStudentFromSchool(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfTryToRemoveNonExistingStudentFromSchoolThrowInvalidOperationException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string studentName = "Ivan Ivanov";
            int studentId = 10000;
            Student student = new Student(studentName, studentId);

            school.RemoveStudentFromSchool(student);
        }

        [TestMethod]
        public void CourseShouldBeRemovedFromSchool()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string courseName = "Hight Quality Code";
            Course course = new Course(courseName);

            school.AddCourseToSchool(course);
            school.RemoveCourseFromSchool(course);
            Assert.IsTrue(school.CoursesInSchool.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfTryToRemoveNullCourseFromSchoolThrowArgumentNullException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            Course course = null;
            
            school.RemoveCourseFromSchool(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfTryToRemoveNonExistingCourseFromSchoolThrowInvalidOperationException()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);

            string courseName = "Hight Quality Code";
            Course course = new Course(courseName);

            school.RemoveCourseFromSchool(course);
        }
    }
}
