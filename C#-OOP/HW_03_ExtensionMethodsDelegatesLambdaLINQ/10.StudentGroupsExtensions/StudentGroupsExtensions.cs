using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;
class StudentGroupsExtensions
{
    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students from GROUP 2!");
        var studentsFromSecondGroup = students.Where(st => st.GroupNumber == 2);

        foreach (var st in studentsFromSecondGroup)
        {
            Console.WriteLine("Name: {0} {1}, Group Nr.: {2}",
                st.FirstName,
                st.LastName,
                st.GroupNumber);
        }

        Console.WriteLine("\nStudents from GROUP 2 ordered by first name!");
        var studentsFromSecondGroupOrderedByFirstName = studentsFromSecondGroup.OrderBy(st => st.FirstName);
        foreach (var st in studentsFromSecondGroupOrderedByFirstName)
        {
            Console.WriteLine("Name: {0} {1}, Group Nr.: {2}",
                st.FirstName,
                st.LastName,
                st.GroupNumber);
        }
    }
}

