using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;
        //private IVehicle car;
        //private IVehicle truck;

        private Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            vehicles.Add(BuildVehicleUsingFactory());
            vehicles.Add(BuildVehicleUsingFactory());

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (InsufficientFuelException ife)
                {
                    writer.WriteLine(ife.Message);
                }
                catch (InvalidVehicleTypeException ivte)
                {
                    writer.WriteLine(ivte.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            PrintAllVehicles();
        }

        private IVehicle BuildVehicleUsingFactory()
        {
            string[] vehicleArgs = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);

            IVehicle vehicle = vehicleFactory.CreateVehicle
                (vehicleType, vehicleFuelQuantity, vehicleFuelConsumption);
            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] cmdArgs = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string cmdType = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double arg = double.Parse(cmdArgs[2]);

            IVehicle vehicleToProcess = vehicles
                .FirstOrDefault(x => x.GetType().Name == vehicleType);

            if (vehicleToProcess == null)
            {
                throw new InvalidVehicleTypeException();
            }

            if (cmdType == "Drive")
            {
                writer.WriteLine(vehicleToProcess.Drive(arg));
            }
            else if (cmdType == "Refuel")
            {
                vehicleToProcess.Refuel(arg);
            }
        }

        private void PrintAllVehicles()
        {
            foreach (IVehicle item in vehicles)
            {
                writer.WriteLine(item.ToString());
            }
        }
    }
}
