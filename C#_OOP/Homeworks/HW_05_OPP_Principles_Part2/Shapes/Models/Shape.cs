namespace Shapes.Models
{
    using System;
    using System.Text;
    
    public abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public double Width 
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Shape width cannot be negativa number!");
                }
                this.width = value;
            }
        }

        public double Height 
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Shape height cannot be negativa number!");
                }
                this.height = value;
            }
        }

        public abstract double CalculateSurface();

        //public override string ToString()
        //{
        //    StringBuilder output = new StringBuilder();
        //    output.AppendFormat("Shape: {0}", this.GetType().Name);
        //    return output.ToString();
        //}
    }
}
