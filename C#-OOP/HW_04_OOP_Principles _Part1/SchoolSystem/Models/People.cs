namespace SchoolSystem.Models
{
    using System;
    using SchoolSystem.Interfaces;
    using System.Collections.Generic;
    public abstract class People : IPeople, IComment
    {
        private string name;
        private ICollection<string> comments;

        protected People(string name)
        {
            this.Name = name;
            this.comments = new List<string>();
        }
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "People name cannot be null!");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Peope name cannot be empty string or sequence of white spaces!");
                }

                this.name = value; 
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
