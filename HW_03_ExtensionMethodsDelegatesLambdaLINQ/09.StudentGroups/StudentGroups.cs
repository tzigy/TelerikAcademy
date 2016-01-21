//Problem 9. Student groups

//Select only the students that are from group number 2.
//Use LINQ query. Order the students by FirstName.


using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;

class StudentGroups
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students from GROUP 2!");
        var studentsFromSecondGroup =
            from student in students
            where student.GroupNumber == 2
            select student;

        foreach (var st in studentsFromSecondGroup)
        {
            Console.WriteLine("Name: {0} {1}, Group Nr.: {2}",
                st.FirstName,
                st.LastName,
                st.GroupNumber);
        }

        Console.WriteLine("\nStudents from GROUP 2 ordered by first name!");
        var studentsFromSecondGroupOrderedByFirstName =
            from student in studentsFromSecondGroup
            orderby student.FirstName
            select student;

        foreach (var st in studentsFromSecondGroupOrderedByFirstName)
        {
            Console.WriteLine("Name: {0} {1}, Group Nr.: {2}",
                st.FirstName,
                st.LastName,
                st.GroupNumber);
        }
    }
}

