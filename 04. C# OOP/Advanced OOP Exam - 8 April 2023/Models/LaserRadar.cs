using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int INTERFACE_STANDART = 20082;
        private const int BATTERY_USAGE = 5000;
        public LaserRadar() : base(INTERFACE_STANDART, BATTERY_USAGE)
        {
        }
    }
}
