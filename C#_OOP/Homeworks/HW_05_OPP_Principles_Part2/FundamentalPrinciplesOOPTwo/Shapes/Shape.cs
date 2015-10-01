namespace Shapes
{
    using System;

    public abstract class Shape
    {
        private const string SideCannotBeNegative = "Side cannot be a negative number!";
        
        private double width;
        private double height;
        
        public Shape(double width, double height) 
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(SideCannotBeNegative);
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(SideCannotBeNegative);
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
