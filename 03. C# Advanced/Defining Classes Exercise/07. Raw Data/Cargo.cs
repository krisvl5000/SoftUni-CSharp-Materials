using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Cargo
    {
        private string type;
        private double weight;

        public Cargo(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type { get; set; }

        public double Weight { get; set; }
    }
}
