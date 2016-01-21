namespace Shapes
{
    using System;
    using System.Linq;
    using Shapes.Models;
    class ShapeTests
    {
        static void Main()
        {
            Shape firstTriangle = new Triangle(2, 6);
            Shape firstSquare = new Square(3);
            Shape firstRectangle = new Rectangle(5, 6);
            Shape secondTriangle = new Triangle(4, 6);
            Shape thirdTriangle = new Triangle(3, 7);

            Shape[] shapeArray = {firstTriangle, firstSquare, firstRectangle, secondTriangle, thirdTriangle};

            var orderedShapeArray = shapeArray.OrderBy(x => x.GetType().Name).ThenBy( y => y.CalculateSurface());

            foreach (var shape in orderedShapeArray)
            {
                Console.WriteLine(shape);                
            }

        }
    }
}
