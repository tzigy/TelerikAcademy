namespace CohesionAndCoupling
{
    using System;

    public class Paralelipiped
    {
        private double width;
        private double height;
        private double depth;

        public Paralelipiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }
        
        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = GeometryUtils.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);

            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = GeometryUtils.CalcalculateDistance2D(0, 0, this.Width, this.Height);

            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = GeometryUtils.CalcalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }        

        public double CalculateDiagonalYZ()
        {
            double distance = GeometryUtils.CalcalculateDistance2D(0, 0, this.Height, this.Depth);

            return distance;
        }
    }
}