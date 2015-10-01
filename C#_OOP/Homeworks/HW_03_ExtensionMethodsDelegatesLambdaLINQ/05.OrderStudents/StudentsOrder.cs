//Problem 5. Order students

//    Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
//    Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;

class StudentsOrder
{
    public static IEnumerable<Student> OrderStudentsDescendingLambda(List<Student> students)
    {
        var result = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);
        return result;
    }

    public static IEnumerable<Student> OrderStudentsDescendingLinq(List<Student> students)
    {
        var result =
            from student in students
            orderby student.FirstName descending, student.LastName descending         
            select student;

        return result;
    }

    static void Main()
    {
        List<Student> students = ListOfStudents.GetListOfSudents();
        
        Console.WriteLine("Using Lambda Method");
        var studentsOrderedLambda = OrderStudentsDescendingLambda(students);
        foreach (var student in studentsOrderedLambda)
        {
            Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);
        }

        Console.WriteLine("\nUsing LINQ Method");
        var studentsOrderedLinq = OrderStudentsDescendingLinq(students);
        foreach (var student in studentsOrderedLinq)
        {
            Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);
        }
    }
}

