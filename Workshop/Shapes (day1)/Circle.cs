using System;

namespace Workshop
{
    public class Circle
    {
        private readonly double _radius;
        private const double Pi = Math.PI;

        public Circle(double radius)
        {
            _radius = radius;
        }
        public double Perimeter
        {
            get { return Math.Round(((2*Pi)*_radius),2); }
        }

        public double Area
        {
            get { return Math.Round((Pi * (_radius * _radius)),2); }
            
        }
    }
}