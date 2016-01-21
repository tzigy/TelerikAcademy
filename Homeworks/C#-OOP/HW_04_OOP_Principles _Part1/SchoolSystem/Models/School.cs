namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    class School
    {
        private string name;
        private ICollection<SchoolClass> classes;

        public string Name 
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "School name cannot be null, empty string or white spaces!");
                }

                this.name = value;
            }
        }

        public ICollection<SchoolClass> Classes 
        {
            get { return this.classes; }
        }

        public void AddClass(SchoolClass newClass)
        {
            this.classes.Add(newClass);
        }

    }
}
