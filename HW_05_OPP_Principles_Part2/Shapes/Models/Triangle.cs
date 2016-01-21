namespace Shapes.Models
{
    using System;
    using System.Text;
    class Triangle : Shape
    {
        public Triangle(double side, double height)
            : base (side, height)
        {

        }

        public override double CalculateSurface()
        {
            double surface = (this.Width * this.Height) / 2;
            return surface;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Shape: {0}; Side={1}; Height={2}; Surface={3}",
                this.GetType().Name,
                this.Width,
                this.Height,
                this.CalculateSurface());
            return output.ToString();
        }
    }
}
