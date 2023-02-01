using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Heigth = height;
            Width = width;
        }

        public double Heigth { get; private set; }

        public double Width { get; private set; }

        public override double CalculateArea()
        {
            return Heigth * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Heigth + 2 * Width;
        }

        public override string Draw()
        {
            return $"Drawing {typeof(Rectangle)}";
        }
    }
}
