namespace Abstraction
{
    using System;
    using Abstraction.Interfaces;

    public abstract class Figure : IFigure
    {
        public Figure()
        {            
        }
       
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();        
    }
}