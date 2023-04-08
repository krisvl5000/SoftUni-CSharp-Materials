using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;

            BatteryLevel = BatteryCapacity;
            interfaceStandards = new List<int>();
        }

        private string model;

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.ModelNullOrWhitespace));
                }
                model = value;
            }
        }

        private int batteryCapacity;

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.BatteryCapacityBelowZero));
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; } // if it does not work, set it through a field

        public int ConvertionCapacityIndex { get; private set; }

        private List<int> interfaceStandards;
        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();// if it does not work, remove readonly

        public void Eating(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                if (BatteryLevel >= BatteryCapacity)
                {
                    BatteryLevel = BatteryCapacity;
                    break;
                }
                BatteryLevel += ConvertionCapacityIndex * minutes;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} {Model}:"); // if not, try typeof
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");

            if (interfaceStandards.Count > 0)
            {
                sb.AppendLine($"--Supplements installed: {String.Join(" ", interfaceStandards)}");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: none");
            }

            return sb.ToString().Trim();
        }
    }
}
