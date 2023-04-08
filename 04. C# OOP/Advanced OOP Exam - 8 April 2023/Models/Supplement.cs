using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        public Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        public int InterfaceStandard { get; }
        public int BatteryUsage { get; }
    }
}
