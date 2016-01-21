using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;

class ExtractStudentsWithTwoMarks
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students with exact two marks 2!");
        var studentsWithTwoMarks = students.Where(st => st.Marks.FindAll(x => x == 2).Count == 2);

        foreach (var st in studentsWithTwoMarks)
        {
            Console.WriteLine("Name: {0} {1}", st.FirstName, st.LastName);
        }
    }
}

