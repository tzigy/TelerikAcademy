using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;
class ExtractMarks
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();
        var studentsIn2006 =
            from student in students
            where student.FN.ToString().EndsWith("06")
            select new
            {
                Fullname = string.Format("{0} {1}", student.FirstName, student.LastName),
                Marks = student.Marks
            };

        foreach (var st in studentsIn2006)
        {
            Console.Write("\nName: {0}\n Marks: ", 
                st.Fullname);
            foreach (var mark in st.Marks)
            {
                Console.Write(" ({0}) ", mark);
            }
        }

    }
}

