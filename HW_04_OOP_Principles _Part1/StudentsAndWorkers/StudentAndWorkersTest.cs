namespace StudentsAndWorkers
{
    using System;
    using System.Linq;
    using StudentsAndWorkers.Models;
    using System.Collections.Generic;

    class StudentAndWorkersTest
    {
        static void Main()
        {
            // POINT 1;
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Ivanov", 56));
            students.Add(new Student("Stoian", "Stoianov", 66));
            students.Add(new Student("Ivan", "Ivankov", 46));
            students.Add(new Student("Dimitar", "Berbatov", 85));
            students.Add(new Student("Iva", "Ivanova", 96));
            students.Add(new Student("Anna", "Garavalova", 73));
            students.Add(new Student("Marta", "Vachkova", 80));
            students.Add(new Student("Goran", "Bregovich", 97));
            students.Add(new Student("Grigor", "Dimitrov", 89));
            students.Add(new Student("Tzvetana", "Pironkova", 59));

            Console.WriteLine("Students ordered by grade using LINQ!");
            var studentsOrderedByGradeLinq =
                from student in students
                orderby student.Grade
                select student;

            foreach (var student in studentsOrderedByGradeLinq)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine("Students ordered by grade using extension OrderBy!");

            var studentsOrderedByGrade = students.OrderBy(student => student.Grade);

            foreach (var student in studentsOrderedByGrade)
            {
                Console.WriteLine(student);
            }

            // POINT 2;
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Ivan", "Gospodinov"));
            workers.Add(new Worker("Ivan", "Georgiev"));
            workers.Add(new Worker("Georgi", "Ivanov"));
            workers.Add(new Worker("Gergana", "Gospodinova", 250, 4));
            workers.Add(new Worker("Ivanka", "Vulcheva", 150, 3));
            workers.Add(new Worker("Ganka", "Pesheva", 400, 6));
            workers.Add(new Worker("Kamen", "Kamenov", 600, 8));
            workers.Add(new Worker("Ivailo", "Zahariev", 900, 8));
            workers.Add(new Worker("Kalina", "Atanasova", 500, 8));
            workers.Add(new Worker("Petia", "Petrova", 550, 8));

            Console.WriteLine("Workers ordered by money per hour using extension OrderBy!");

            var workersOrderedBymoneyPerHour = workers.OrderByDescending(worker => worker.MoneyPerHour());

            foreach (var worker in workersOrderedBymoneyPerHour)
            {
                Console.WriteLine(worker);
            }

            // POINT 3;

            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            Console.WriteLine();
            Console.WriteLine("Students and workers ordered by first name than by second name!");

            var humansOrderedByName = humans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var human in humansOrderedByName)
            {
                Console.WriteLine("Name: {0} {1}", human.FirstName, human.LastName);
            }

        }
    }
}
