using System;
using Workshop;
using Workshop.DI;
using Workshop.Drawers;
using Workshop.Drawers.Contracts;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider diProvider = DependencyInjectionService.ConfigureServices();

            // it creates engine, checks what type of drawer the engine expects, and then passes the drawer to the engine

            Engine engine = (Engine)diProvider.GetService(typeof(Engine));

            engine.Run();
        }
    }
}