namespace Shapes.Models
{
    using System;
    using System.Text;
    class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            :base(width, height)
        {

        }
        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Shape: {0}; Width={1}; Height={2}; Surface={3}",
                this.GetType().Name,
                this.Width,
                this.Height,
                this.CalculateSurface());
            return output.ToString();
        }
    }
}
