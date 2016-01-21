namespace StudentAndPersonClasses.Models
{
    using System;
    using System.Text;
    class Student : Person, ICloneable, IComparable<Student>
    {
        private int ssn;
        private string address; // it can be done by new class        
        private string phone;
        private string email;
        private string course;
        private Specialty specialty;
        private University university;
        private Faculty faculty;

        public Student(string firstName, string middleName, string lastName, int ssn)
            : base(firstName, middleName, lastName)
        {
            this.SSN = ssn;
        }

        public Student(string firstName, string middleName, string lastName, int ssn, string address, string phone, string email, string course, Specialty specialty, University university, Faculty faculty)
            : this(firstName, middleName, lastName, ssn)
        {
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public int SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid SSN!");
                }
                this.ssn = value;
            }
        }
        public string Address
        {
            get { return this.address; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Address cannot be null, empty string or sequence of white spaces! ");
                }
                this.address = value;
            }
        }        
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }

        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }


        public override bool Equals(object obj)
        {
            Student temp = obj as Student;
           
            //I accept that two Students are equal if they hava the same name and the same SSN
            if (! this.FullName.Equals(temp.FullName)){ return false;}           
            if (!this.SSN.Equals(temp.SSN)) { return false; }
            
            return true;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode() ^ SSN.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Name: {0}", this.FullName);
            output.AppendFormat("\n-->SSN: {0}", this.SSN);
            output.AppendFormat("\n-->Address: {0}", this.Address == null ? "<no address>" : this.Address);
            output.AppendFormat("\n-->Phone: {0}", this.Phone == null ? "<no phone>" : this.Phone);
            output.AppendFormat("\n-->Email: {0}", this.Email == null ? "<no email>" : this.Email);
            output.AppendFormat("\n-->Course: {0}", this.Course == null ? "<no course>" : this.Course);
            output.AppendFormat("\n-->Specialty: {0}", StringEnum.GetStringValue(this.Specialty));
            output.AppendFormat("\n-->University: {0}", StringEnum.GetStringValue(this.University));
            output.AppendFormat("\n-->Faculty: {0}", StringEnum.GetStringValue(this.Faculty));

            return output.ToString();
        }


        public object Clone()
        {
            var clonedStudent = new Student
            (
                (string)this.FirstName.Clone(), 
                (string)this.MiddleName.Clone(), 
                (string)this.LastName.Clone(),
                SSN = this.SSN,
                (string)this.Address.Clone(), 
                (string)this.Phone.Clone(),
                (string)this.Email.Clone(),
                (string)this.Course.Clone(),
                this.Specialty,
                this.University,
                this.Faculty
            );

            return clonedStudent;
        }

        public int CompareTo(Student other)
        {            
            if (this.FullName.CompareTo(other.FullName) == 0)
            {
                return this.SSN.CompareTo(other.SSN);
            }
            return this.FullName.CompareTo(other.FullName);
        }
    }
}
