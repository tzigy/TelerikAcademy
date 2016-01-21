namespace MyStudent
{
    using System;
    using System.Collections.Generic;
    public class ListOfStudents
    {
        public static List<Student> GetListOfSudents()
        {
            List<Student> listOfSudents = new List<Student>()
            {
                new Student 
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    FN = 0000106,
                    Gender = GenderType.Male,
                    Age = 19,
                    PhoneNumber = "02 367 586",
                    Email = "ivan_ivanov@abv.bg",
                    GroupNumber = 1,
                    Marks = new List<int>(){6, 6, 5, 6}

                },

                new Student 
                {
                    FirstName = "Sasho",
                    LastName = "Ivankov",
                    FN = 0000705,
                    Gender = GenderType.Male,
                    Age = 25,
                    PhoneNumber = "02 854 586",
                    Email = "sasho_ivankovv@abv.bg",
                    GroupNumber = 3,
                    Marks = new List<int>(){6, 6, 5, 6}

                },

                new Student 
                {
                    FirstName = "Ivan",
                    LastName = "Markov",
                    FN = 0000206,
                    Gender = GenderType.Male,
                    Age = 18,
                    PhoneNumber = "02 287 586",
                    Email = "ivan_markov@abv.bg",
                    GroupNumber = 1,
                    Marks = new List<int>(){4, 5, 6, 3}

                },

                new Student 
                {
                    FirstName = "Stefan",
                    LastName = "Stefanov",
                    FN = 0000306,
                    Gender = GenderType.Male,
                    Age = 21,
                    PhoneNumber = "02 237 576",
                    Email = "stefan_stefanov@mail.bg",
                    GroupNumber = 2,
                    Marks = new List<int>(){5, 5, 6, 5, 4}

                },

                new Student 
                {
                    FirstName = "Iva",
                    LastName = "Pesheva",
                    FN = 0000406,
                    Gender = GenderType.Female,
                    Age = 21,
                    PhoneNumber = "0887 337 476",
                    Email = "iva_pesheva@gmail.com",
                    GroupNumber = 2,
                    Marks = new List<int>(){4, 5, 4, 6, 5}

                },

                new Student 
                {
                    FirstName = "Stefka",
                    LastName = "Dgongova",
                    FN = 0000505,
                    Gender = GenderType.Female,
                    Age = 20,
                    PhoneNumber = "0887 444 476",
                    Email = "stefka_dgongova@abv.bg",
                    GroupNumber = 1,
                    Marks = new List<int>(){6, 5, 6, 6, 6, 2}

                },

                new Student 
                {
                    FirstName = "Anka",
                    LastName = "Vankova",
                    FN = 0000806,
                    Gender = GenderType.Female,
                    Age = 26,
                    PhoneNumber = "0887 333 476",
                    Email = "anka_vankova@abv.bg",
                    GroupNumber = 3,
                    Marks = new List<int>(){2, 5, 4, 4, 4, 2}

                }
            };

            return listOfSudents;
        }
    }
}
