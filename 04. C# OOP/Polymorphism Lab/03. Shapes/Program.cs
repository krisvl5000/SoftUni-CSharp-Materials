using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Circle(5.0);
            Shape rectangle = new Rectangle(34.0, 434.0);
            Console.WriteLine(shape.Draw());
            Console.WriteLine(rectangle.Draw());

        }
    }
}