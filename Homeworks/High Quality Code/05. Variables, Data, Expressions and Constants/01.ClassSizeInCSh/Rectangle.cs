using System;

public class Rectangle
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width 
    {
        get
        {
            return this.width;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Width cannot be negative!");
            }
        } 
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Height cannot be negative!");
            }
        }
    }

    public static Rectangle RotatedRectangle(Rectangle rectangle, double angleOfRotation)
    {
        double rotatedWidth = (Math.Abs(Math.Cos(angleOfRotation)) * rectangle.Width) +
                (Math.Abs(Math.Sin(angleOfRotation)) * rectangle.Height);

        double rotatedHeight = (Math.Abs(Math.Sin(angleOfRotation)) * rectangle.Width) +
                (Math.Abs(Math.Cos(angleOfRotation)) * rectangle.Height);

        Rectangle rotatedRectangle = new Rectangle(rotatedWidth, rotatedHeight);

        return rotatedRectangle;
    }
}