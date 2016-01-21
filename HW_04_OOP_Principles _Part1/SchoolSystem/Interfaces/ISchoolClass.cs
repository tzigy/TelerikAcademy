namespace SchoolSystem.Interfaces
{
    using System;
    public interface ISchoolClass
    {
        string ClassID { get;}
        void AddStudent(IStudent student);
        void AddTeacher(ITeacher teacher);
    }
}
