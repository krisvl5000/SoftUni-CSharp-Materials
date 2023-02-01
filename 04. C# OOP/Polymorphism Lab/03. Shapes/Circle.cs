using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }

        public override double CalculateArea()
        {
            return 2 * Math.PI * Radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * Radius * Radius;
        }

        public override string Draw()
        {
            return $"Drawing {this.GetType().Name}";
        }
    }
}
