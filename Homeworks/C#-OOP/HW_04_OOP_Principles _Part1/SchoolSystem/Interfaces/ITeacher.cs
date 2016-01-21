namespace SchoolSystem.Interfaces
{
    using System;
    public interface ITeacher : IPeople
    {
        void AddDiscipline(IDiscipline discipline);
    }
}
