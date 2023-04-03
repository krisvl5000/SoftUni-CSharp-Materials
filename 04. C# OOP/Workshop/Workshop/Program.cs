using System;
using Workshop;
using Workshop.Drawers;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicShapeDrawer drawer = new BasicShapeDrawer();

            Engine engine = new Engine(drawer);

            engine.Run();
        }
    }
}