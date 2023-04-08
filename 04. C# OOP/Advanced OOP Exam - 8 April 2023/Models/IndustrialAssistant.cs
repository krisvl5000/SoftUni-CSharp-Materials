using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int BATTERY_CAPACITY = 40000;
        private const int CONVERSION_CAPACITY_INDEX = 5000;
        public IndustrialAssistant(string model) : base(model, BATTERY_CAPACITY, CONVERSION_CAPACITY_INDEX)
        {
        }
    }
}
