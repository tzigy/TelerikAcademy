
namespace EuclidianSpace
{
    using System;
    public static class DistanceCalculator
    {
        public static double CalculateDistanceBetweenTwoPoints(Point3D firstPoint, Point3D secondPoint)
        {
            double coordXDistance = firstPoint.CoordX - secondPoint.CoordX;
            double coordYDistance = firstPoint.CoordY - secondPoint.CoordY;
            double coordZDistance = firstPoint.CoordZ - secondPoint.CoordZ;
            double euclidianDistance = Math.Sqrt(Math.Pow(coordXDistance, 2) + Math.Pow(coordYDistance, 2) + Math.Pow(coordZDistance, 2));
            return euclidianDistance;
        }

    }
}
