//Problem 13. Extract students by marks

//Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
//Use LINQ.


using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;


class ExtractStudentsByMarks
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students that have at least one mark Excellent (6)!");

        var studentsWithExcellentMark =
            from student in students
            where student.Marks.Contains(6)
            select new
            {
                FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                Marks = student.Marks
            };

        foreach (var st in studentsWithExcellentMark)
        {
            Console.WriteLine("\nName: {0}", st.FullName);
            foreach (var mark in st.Marks)
            {
                Console.Write(" ({0}) ", mark);
            }

        }

    }
}

