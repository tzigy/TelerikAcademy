namespace RangeExeption
{
    using System;
    using System.Text;
    class InvalidRangeException<T> : ApplicationException
    {
        private T start;
        private T end;

        public InvalidRangeException(T start, T end)
            : this(string.Empty, start, end, null)
        {

        }

        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {

        }
        
        
        public InvalidRangeException(string message, T start, T end, Exception causeException)
            : base(message, causeException)
        {
            this.start = start;
            this.end = end;
        }
 
        

 
        public T Start
        {
            get 
            { 
                return this.start; 
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Start range cannot be null!");
                }
                else
                {
                    this.start = value;
                }
            }
        }
 
        public T End
        { 
            get
            {
                return this.end; 
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("End range cannot be null!");
                }
                else
                {
                    this.end = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Invalid input. Parameters should be in the range {0} - {1}!", this.Start, this.End);
            return output.ToString();
        }
    }
}
