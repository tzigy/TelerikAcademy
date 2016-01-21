//Problem 12. Extract students by phone

//    Extract all students with phones in Sofia.
//    Use LINQ.


using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;

class ExtractStudentsByPhone
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students with phone in Sofia!");

        var phoneInSofia =
            from student in students
            where student.PhoneNumber.StartsWith("02") ||
                  student.PhoneNumber.StartsWith("+359 2") ||
                  student.PhoneNumber.StartsWith("00359 2")
            select student;
        foreach (var st in phoneInSofia)
        {
            Console.WriteLine("Name: {0} {1}, Phone number: {2}",
                st.FirstName,
                st.LastName,
                st.PhoneNumber);
        }
    }
}

