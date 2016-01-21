namespace Abstraction
{
    using System;
    using Abstraction.Interfaces;    

    public class Rectangle : Figure, IFigure
    {
        private double width;
        private double height;
        
        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                ///TODO: implement validations
                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                ///TODO: implement validations
                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
