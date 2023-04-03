using System;
using Workshop;
using Workshop.Drawers;
using Workshop.Drawers.Contracts;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShapeDrawer drawer = new AdvancedShapeDrawer();

            Engine engine = new Engine(drawer);

            engine.Run();
        }
    }
}