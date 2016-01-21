namespace Abstraction
{
    using System;
    using Abstraction.Interfaces;    

    public class Circle : Figure, IFigure
    {
        private double radius;

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public virtual double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                ///TODO: implement validations
                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
