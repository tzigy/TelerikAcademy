//Problem 11. Extract students by email

//    Extract all students that have email in abv.bg.
//    Use string methods and LINQ.


using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;

class ExtractStudentsByEmail
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students that have email in ABV!");

        var emailInAbv =
            from student in students
            where student.Email.Contains("abv.bg")
            select student;

        foreach (var st in emailInAbv)
        {
            Console.WriteLine("Name: {0} {1}, Email: {2}",
                st.FirstName,
                st.LastName,
                st.Email);
        }
    }
}

