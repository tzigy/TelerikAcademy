namespace EuclidianSpace
{
    using System;
    public struct Point3D  
    {
        private static readonly Point3D startPoint = new Point3D(0, 0, 0);
        private double coordX;
        private double coordY;
        private double coordZ;

        public Point3D(double coordX, double coordY, double coordZ) : this()
        {
            this.coordX = coordX;
            this.coordY = coordY;
            this.coordZ = coordZ;
        }

        static Point3D()
        {
            startPoint = new Point3D(0, 0, 0);
        }
        static Point3D StartPoint
        {
            get 
            {
                return startPoint;
            }
        }
        public double CoordX 
        {
            get { return this.coordX; }
            set { this.coordX = value; } 
        }
        public double CoordY 
        {
            get { return this.coordY; }
            set { this.coordY = value; }
        }
        public double CoordZ 
        {
            get { return this.coordZ; }
            set { this.coordZ = value; }
        }

        public override string ToString()
        {
            string pointCoordsAsString = string.Format("({0:F2}, {1:F2}, {2:F2})", this.CoordX, this.CoordY, this.CoordZ);
            return pointCoordsAsString;
        }
        
    }
}
