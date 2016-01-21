using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemsSolved = 0;
    private const int MaxProblemsSolved = 10;
    private const int PoorGrade = 2;
    private const int AverageGrade = 3;
    private const int GoodGrade = 4;
    private const int VeryGoodGrade = 5;
    private const int ExcellentGrade = 6;
    private const string PoorGradeComment = "Poor result: nothing done.";
    private const string AverageGradeComment = "Average result: almost nothing done.";
    private const string GoodGradeComment = "Good result: can be better.";
    private const string VeryGoodGradeComment = "Very good result: almost everything done.";
    private const string ExcellentGradeComment = "Excellent result: congratulations everything done.";


    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {        
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved 
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved || MaxProblemsSolved < value)
            {
                throw new ArgumentOutOfRangeException("Ivalid number of solved problems! Number of solved problems must be berween " + MinProblemsSolved + " and " + MaxProblemsSolved + "!");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        int grade;
        string comment;        

        if (this.ProblemsSolved <=2)
        {
            grade = PoorGrade;
            comment = PoorGradeComment;
        }
        else if (this.ProblemsSolved <= 4)
        {
            grade = AverageGrade;
            comment = AverageGradeComment;
        }
        else if (this.ProblemsSolved <= 6)
        {
            grade = GoodGrade;
            comment = GoodGradeComment;
        }

        else if (this.ProblemsSolved <= 8)
        {
            grade = VeryGoodGrade;
            comment = VeryGoodGradeComment;
        }
        else
        {
            grade = ExcellentGrade;
            comment = ExcellentGradeComment;
        }

        return new ExamResult(grade, PoorGrade, ExcellentGrade, comment);
    }
}