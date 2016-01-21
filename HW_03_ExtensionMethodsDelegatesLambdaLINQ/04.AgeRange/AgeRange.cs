//Problem 4. Age range

//    Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.


using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;

class AgeRange
{
    //public static Student[] FindStudentsInAgeRangeArray(Student[] students, int rangeStart, int rangeEnd)
    //{
    //    var result =
    //        from student in students
    //        where student.Age >= rangeStart && student.Age <= rangeEnd
    //        select student;

    //    return result.ToArray();
    //}

    public static IEnumerable<Student> FindStudentsInAgeRange(Student[] students, int rangeStart, int rangeEnd)
    {
        var result =
            from student in students
            where student.Age >= rangeStart && student.Age <= rangeEnd
            select student;

        return result.ToArray();
    }
    static void Main()
    {
        Student[] students = ListOfStudents.GetListOfSudents().ToArray();
        var studentInAgeRange = FindStudentsInAgeRange(students, 18, 24);

        foreach (var st in studentInAgeRange)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}", st.FirstName, st.LastName, st.Age);
        }

    }
}

