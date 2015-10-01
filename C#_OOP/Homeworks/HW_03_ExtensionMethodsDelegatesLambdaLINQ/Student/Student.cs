namespace MyStudent
{
    using System;
    using System.Collections.Generic;
    public class Student
    {
        private string firstName;
        private string lastName;
        private int facNumber;
        private int age;
        private GenderType gender;
        private string phoneNumber;
        private string email;
        private List<int> marks;
        private int groupNumber;         

        //public Student(string firstName, string secondName, int facNumber, GenderType gender)
        //{
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.FN = facNumber;
        //    this.Gender = gender;

        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FN 
        {
            get { return this.facNumber; }
            set { this.facNumber = value; } 
        }

        public int Age { get; set; }
        public GenderType Gender { get; set; }

        public string PhoneNumber 
        {
            get
            {
                if (string.IsNullOrEmpty(this.phoneNumber))
                {
                    return "<no phone number>";
                }

                return this.phoneNumber;
            }

            set { this.phoneNumber = value; } 
        }

        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }


        static void Main(string[] args)
        {
        }
    }
}
