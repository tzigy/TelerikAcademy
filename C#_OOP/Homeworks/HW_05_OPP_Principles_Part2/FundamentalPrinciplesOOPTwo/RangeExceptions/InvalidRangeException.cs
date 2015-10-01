namespace RangeExceptions
{
    using System;
    
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T start, T end, Exception inner)
            : base(message, inner)
        {
            this.Start = start;
            this.End = end;
        }
        public InvalidRangeException(string message, T start, T end)
            : base(message)
        {
        }

        public T Start { get; private set; }
        public T End { get; private set; }
    }
}
