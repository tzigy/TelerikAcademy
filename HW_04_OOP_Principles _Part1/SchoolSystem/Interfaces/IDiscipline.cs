namespace SchoolSystem.Interfaces
{
    using System;
    public interface IDiscipline 
    {
        string Name { get; }
        int NumberOfLectures { get; }
        int NumberOfExercises { get; }
    }
}
