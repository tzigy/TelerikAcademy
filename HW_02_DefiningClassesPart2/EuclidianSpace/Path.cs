namespace EuclidianSpace
{
    using System;
    using System.Collections.Generic;
    using System.Text;
     public class Path 
    {
        private const int INITIAL_LIST_CAPACITY = 4;
        private List<Point3D> pointPath;

        public Path() 
            : this(INITIAL_LIST_CAPACITY)
        {
        }

        public Path(int listCapacity)
        {
            this.pointPath = new List<Point3D>(listCapacity);
        }

        public int Count
        {
            get { return this.PointPath.Count; }
        }

        public List<Point3D> PointPath
        {
            get
            {
                return this.pointPath;
            }
        }

        public void AddPointToPath(Point3D point)
        {
            this.PointPath.Add(point);
        }

        public void RemovePointFromPath(Point3D point)
        {
            this.PointPath.Remove(point);
        }

        public void ClearPath()
        {
            this.PointPath.Clear();
        }

        public override string ToString()
        {
            StringBuilder printedString = new StringBuilder();
            
            for (int i = 0; i < this.PointPath.Count; i++)
            {         
                printedString.AppendLine(string.Format("Point {0} -> ({1}, {2}, {3})", (i + 1), PointPath[i].CoordX, this.PointPath[i].CoordY, this.PointPath[i].CoordZ));    
            }
            return printedString.ToString();
        }
    }
}
