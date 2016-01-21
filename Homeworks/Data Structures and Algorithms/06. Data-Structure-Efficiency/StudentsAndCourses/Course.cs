namespace StudentsAndCourses
{
    using System;

    public class Course : IComparable<Course>, IEquatable<Course>
    {
        public string Name { get; set; }

        public Course(string name)
        {
            this.Name = name;
        }

        public bool Equals(Course other)
        {            
            return this.Name.CompareTo(other.Name) == 0;
        }

        public int CompareTo(Course other)
        {
            int result = string.Compare(this.Name, other.Name, true);

            return result;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Course);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
