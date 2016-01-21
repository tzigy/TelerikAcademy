namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static object StreamReader { get; private set; }

        public static void Main()
        {
            IDictionary<Course, List<Student>> courses = ReadInputFile("students.txt");

            foreach (var course in courses)
            {
                Console.WriteLine("{0}: {1}", course.Key, PrintStudents(course.Value));
            }


        }

        private static IDictionary<Course, List<Student>> ReadInputFile(string inputFile)
        {
            StreamReader reader = new StreamReader("../../" + inputFile);
            IDictionary<Course, List<Student>> courses = new SortedDictionary<Course, List<Student>>();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] lineElements = line.Split('|').Select(str => str.Trim()).ToArray();
                    Course course = new Course(lineElements[2]);
                    Student st = new Student(lineElements[0], lineElements[1]);

                    if (courses.ContainsKey(course))
                    {
                        courses[course].Add(st);
                    }
                    else
                    {
                        courses.Add(course, new List<Student> { st });
                    }

                    line = reader.ReadLine();
                }

                return courses;
            }
        }

        private static string PrintStudents(List<Student> students)
        {
            StringBuilder output = new StringBuilder();

            students.Sort();

            foreach (var student in students)
            {

                output.AppendFormat("{0}, ", student.ToString());
            }

            return output.ToString().Substring(0, output.Length - 2);
        }
    }
}
