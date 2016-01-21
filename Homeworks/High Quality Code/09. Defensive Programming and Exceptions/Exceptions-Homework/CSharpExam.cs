using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;

    private int score;    

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < CSharpExam.MinScore || CSharpExam.MaxScore < value)
            {
                throw new ArgumentOutOfRangeException("Invalid exam score value! Exam score cannot be negative number or bigger than 100!");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        /// No need to check if score is in range, because we did it in constructor(by making the object and using the property)
        ExamResult examResult = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");

        return examResult;
    }
}