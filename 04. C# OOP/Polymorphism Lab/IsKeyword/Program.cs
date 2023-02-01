using System;

namespace IsKeyword
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape;

            if (new Random().Next() % 2 == 0)
            {
                shape = new Circle();
            }
            else
            {
                shape = new Rectangle();
            }

            shape.Draw();

            if (shape is Circle)
            {
                int radius = ((Circle)shape).Raduis;
                Console.WriteLine(radius);
            }

        }
    }
}