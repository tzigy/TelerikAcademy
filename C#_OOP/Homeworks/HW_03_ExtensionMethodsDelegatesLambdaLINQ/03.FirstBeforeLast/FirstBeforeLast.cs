//Problem 3. First before last

//    Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
//    Use LINQ query operators.


using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;
class FirstBeforeLast
{
    //public static List<Student> FirstBeforeLastLambda(List<Student> listOfStudents)
    //{
    //    var firstBeforeLastList = listOfStudents.FindAll(st => st.FirstName.CompareTo(st.LastName) <= 0);
    //    return firstBeforeLastList;
    //}

    //public static IEnumerable<Student> FirstBeforeLastLinq(List<Student> listOfStudents)
    //{
    //    var result =
    //        from student in listOfStudents
    //        where (student.FirstName.CompareTo(student.LastName) <= 0)
    //        select  student;

    //    return result;
    //}

    public static Student[] FirstBeforeLastLambda(Student[] students)
    {
        var firstBeforeLastList = Array.FindAll(students, st => st.FirstName.CompareTo(st.LastName) <= 0);
        return firstBeforeLastList.ToArray();
    }

    public static Student[] FirstBeforeLastLinq(Student[] students)
    {
        var result =
            from student in students
            where (student.FirstName.CompareTo(student.LastName) <= 0)
            select student;

        return result.ToArray();
    }

    static void Main()
    {
        //List<Student> students = ListOfStudents.GetListOfSudents();
        Student[] students = ListOfStudents.GetListOfSudents().ToArray();

        Console.WriteLine("Lambda method:");
        var studentsListLambda = FirstBeforeLastLambda(students);
        foreach (var st in studentsListLambda)
        {
            Console.WriteLine("Name: {0} {1}", st.FirstName, st.LastName);
        }

        Console.WriteLine("Linq method:");
        var studentsListLinq = FirstBeforeLastLinq(students);
        foreach (var st in studentsListLinq)
        {
            Console.WriteLine("Name: {0} {1}", st.FirstName, st.LastName);
        }

    }

}

