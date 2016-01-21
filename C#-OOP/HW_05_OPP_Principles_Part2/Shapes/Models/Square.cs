namespace Shapes.Models
{
    using System;
    using System.Text;
    class Square : Rectangle
    {
        public Square(double side)
            : base(side, side)
        {

        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Shape: {0}; Width=Height{1};  Surface={2}",
                this.GetType().Name,
                this.Width,                
                this.CalculateSurface());
            return output.ToString();
        }
    }
}
