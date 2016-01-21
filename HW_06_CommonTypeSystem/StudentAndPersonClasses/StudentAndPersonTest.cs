namespace StudentAndPersonClasses
{
    using StudentAndPersonClasses.Models;
    using System;
    class StudentAndPersonTest
    {
        static void Main()
        {
            Student firstStudent = new Student("Grigor", "Grigorov", "Dimitrov", 123456789, "Best 40 Str.", "+359 887 256 025", "gdimitrov@abv.bg", "3", Specialty.Inssurance, University.UNSS, Faculty.GeneralEconomics);

            Student secondStudent = new Student("Georgi", "Ivanov", "Stoianov", 231456789, "George 21A Str.", "+359 887 256 025", "gstoianov@mail.bg", "2", Specialty.ComputerScience, University.SofiaUniversity, Faculty.ComputerScience);

            var thirdStudent = firstStudent.Clone() as Student;            
            Console.WriteLine("Compare first student and second student using Equal: {0}", firstStudent.Equals(secondStudent));
            Console.WriteLine("Compare first student and second student using == operator: {0}", firstStudent == secondStudent);
            Console.WriteLine("Compare first student and third student using Equal: {0}", firstStudent.Equals(thirdStudent));
            Console.WriteLine("Compare first student and third student using != operator: {0}", firstStudent != thirdStudent);

            Console.WriteLine();
            Console.WriteLine("Changing the SSN of the third student, which is clone of the first student!");
            thirdStudent.SSN = 122456789;
            Console.WriteLine("Compare first student and third student using Equal: {0}", firstStudent.Equals(thirdStudent));
            Console.WriteLine();
            Console.WriteLine("The result of comparing first student with third student is: {0}", firstStudent.CompareTo(thirdStudent));

            Console.WriteLine();
            Console.WriteLine("Printing the all information for the first student using ToString method!");
            Console.WriteLine(firstStudent);

            Console.WriteLine();
            Console.WriteLine("Test for class Person!");
            Person firstPerson = new Person("Ivan Ivanov Ivanov");
            Person secondPerson = new Person("Grigor Grigorov Dimitrov", 23);
            Person thirdPerson = new Person("Pesho", "Peshev", "Peshev");
            Console.WriteLine();
            Console.WriteLine(firstPerson);
            Console.WriteLine();
            Console.WriteLine(secondPerson);
            Console.WriteLine();
            Console.WriteLine(thirdPerson);
        }
    }
}
