using System;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory factory = new VehicleFactory();

            IEngine engine = new Engine(reader, writer, factory);
            engine.Run();
        }
    }
}