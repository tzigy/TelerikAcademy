//Problem 16.* Groups

//    Create a class Group with properties GroupNumber and DepartmentName.
//    Introduce a property GroupNumber in the Student class.
//    Extract all students from "Mathematics" department.
//    Use the Join operator.


using System;
using System.Collections.Generic;
using System.Linq;
using MyStudent;


class Groups
{
    static void Main()
    {
        List<Group> groups = new List<Group>(){
              new Group {
                    GroupNumber = 1,
                    DepartmentName = "Mathematics"
                  },
              new Group {
                    GroupNumber = 2,
                    DepartmentName = "Phisics"
                  },
              new Group {
                    GroupNumber = 3,
                    DepartmentName = "Computer Science"
                  }
           };

        List<Student> students = ListOfStudents.GetListOfSudents();

        Console.WriteLine("Students from the Mathematics department:");

        var studentsFromMathDepartment =
            from gr in groups
            where gr.DepartmentName == "Mathematics"
            join student in students
            on gr.GroupNumber
            equals student.GroupNumber
            select new 
                {
                    FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                    DepartmentName = gr.DepartmentName
                };

        foreach (var st in studentsFromMathDepartment)
        {
            Console.WriteLine("Name: {0}\n--->Department: {1}\n", st.FullName, st.DepartmentName);
        }


        //var studentsFromMathDepartment =
        //    from student in students
        //    where student.GroupNumber == 1
        //    join gr in groups
        //    //where gr.DepartmentName == "Mathematics"
        //    on student.GroupNumber
        //    equals gr.GroupNumber
        //    select student;

    }
}

