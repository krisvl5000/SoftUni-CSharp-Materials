using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int INTERFACE_STANDART = 10045;
        private const int BATTERY_USAGE = 10000;
        public SpecializedArm() : base(INTERFACE_STANDART, BATTERY_USAGE)
        {
        }
    }
}
