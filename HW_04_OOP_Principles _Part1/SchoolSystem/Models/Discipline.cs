namespace SchoolSystem.Models
{
    using System;
    using SchoolSystem.Interfaces;
    using System.Collections.Generic;    
    public class Discipline : IDiscipline, IComment
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExecises;
        private ICollection<string> comments;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Discipline name cannot be null, empty string or white spaces!");
                }

                this.name = value;
            }
        }
        public int NumberOfLectures 
        {
            get { return this.numberOfLectures; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Discipline must have min one lecture!");
                }
                this.numberOfLectures = value;
            }
        }
        public int NumberOfExercises 
        {
            get { return this.numberOfExecises; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Discipline must have min one exercise!");
                }

                this.numberOfExecises = value;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
