/*Problem 1. Shapes
Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure (height * width for rectangle and height * width/2 for triangle).
Define class Square and suitable constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method.
Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Square, Rectangle, Triangle) stored in an array.*/

namespace Shapes
{
    using System;
    using System.Collections.Generic;

    public class ShapesMain
    {
        public static void Main()
        {
            var arrayOfSquares = new Square[] 
            {
                new Square(5.5),
                new Square(6.7),
                new Square(9.8)
            };

            var arrayOfTriangles = new Triangle[]
            {
                new Triangle(5.5, 6.5),
                new Triangle(15.4, 21.4),
                new Triangle(3.5, 2.1)
            };

            var arrayOfRectangles = new Rectangle[]
            {
                new Rectangle(1.2, 2.5),
                new Rectangle(22.15, 15.5),
                new Rectangle(17.2, 10)
            };

            //First variant
            Console.WriteLine("Calculating the surface of the squares:");
            PrintSurface(arrayOfSquares);

            Console.WriteLine("Calculating the surface of the triangles:");
            PrintSurface(arrayOfTriangles);

            Console.WriteLine("Calculating the surface of the rectangles:");
            PrintSurface(arrayOfRectangles);

            ////Second variant
            //var listOfSurfacesOfSquares = Surfaces(arrayOfSquares);
            //Console.WriteLine(string.Join("\n", listOfSurfacesOfSquares));
        }

        //First varint
        public static void PrintSurface(IEnumerable<Shape> arrayOfShapes)
        {
            foreach (var shape in arrayOfShapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }

        ////Second varint
        //public static IEnumerable<double> Surfaces(IEnumerable<Shape> arrayOfShapes)
        //{
        //    var list = new List<double>();
        //    foreach (var item in arrayOfShapes)
        //    {
        //        list.Add(item.CalculateSurface());
        //    }
        //    return list;
        //}
    }
}
