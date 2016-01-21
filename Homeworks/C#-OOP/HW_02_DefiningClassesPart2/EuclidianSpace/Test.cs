namespace EuclidianSpace
{
    using System;

    class Test
    {
        public static void Main()
        {                   
            Point3D firstPoint = new Point3D(1.1, 2.2, 3.3);
            Point3D secondPoint = new Point3D(3.3, 2.2, 1.1);

            double dist = DistanceCalculator.CalculateDistanceBetweenTwoPoints(firstPoint, secondPoint);
            Console.WriteLine("The distance between points ({0}) and ({1}) is {2:F2}.", firstPoint, secondPoint, dist);
            
            
            Path firstPath = new Path();
            firstPath.AddPointToPath(firstPoint);
            firstPath.AddPointToPath(secondPoint);
            Console.WriteLine(firstPath);

            PathStorage.SavePathToFile(firstPath, "FirstPath.txt");

            Path secondPath = PathStorage.LoadPathFromFile("Points.txt");
            Console.WriteLine(secondPath);

            PathStorage.SavePathToFile(secondPath, "NewPoints.txt");
            
            
        }
    }
}
