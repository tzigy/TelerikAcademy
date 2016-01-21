namespace SchoolSystem.Models
{
    using System;
    using SchoolSystem.Interfaces;    
    using System.Collections.Generic;
    public class Teacher : People, ITeacher, IComment
    {
        private ICollection<IDiscipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.disciplines = new List<IDiscipline>();
        }

        public ICollection<IDiscipline> Disciplines
        {
            get { return this.disciplines; }
        }

        public void AddDiscipline(IDiscipline discipline)
        {
            this.disciplines.Add(discipline);
        }
    }
}
