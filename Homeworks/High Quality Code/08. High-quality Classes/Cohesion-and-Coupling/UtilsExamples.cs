namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                GeometryUtils.CalcalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                GeometryUtils.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            Paralelipiped newParalelipiped = new Paralelipiped(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", newParalelipiped.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", newParalelipiped.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", newParalelipiped.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", newParalelipiped.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", newParalelipiped.CalculateDiagonalYZ());
        }
    }
}