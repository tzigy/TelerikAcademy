using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;

class GroupedByGroupNumber
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students grouped by GROUP NUMBER using LINQ!");
        var groupedByGroupNumber =
            from student in students
            orderby student.GroupNumber
            select student;

        foreach (var st in groupedByGroupNumber)
        {
            Console.WriteLine("Name: {0} {1}, Group number: {2}",
                st.FirstName,
                st.LastName,
                st.GroupNumber);
        }

        Console.WriteLine("\nStudents grouped by GROUP NUMBER using LINQ with extension method!");
        var groupedByGroupNumberWithExtension = students.OrderBy(x => x.GroupNumber);
             

        foreach (var st in groupedByGroupNumberWithExtension)
        {
            Console.WriteLine("Name: {0} {1}, Group number: {2}",
                st.FirstName,
                st.LastName,
                st.GroupNumber);
        }
    }
}

