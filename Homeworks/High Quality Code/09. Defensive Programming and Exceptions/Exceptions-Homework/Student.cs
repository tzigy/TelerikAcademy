using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;   

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = new List<Exam>();

        if (exams != null)
        {
            this.Exams = exams;
        }
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid first name! First name cannot be null, empty string or white spaces!");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid last name! Last name cannot be null, empty string or white spaces!");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams { get; private set; }

    public IList<ExamResult> CheckExams()
    {        
        IList<ExamResult> results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {        
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}