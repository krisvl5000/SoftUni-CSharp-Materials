using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double fishLength;
        private double fishWeight;

        public Fish(string fishType, double fishLength, double fishWeight)
        {
            Type = fishType;
            Length = fishLength;
            Weight = fishWeight;
        }

        public string Type { get; set; }

        public double Length { get; set; }

        public double Weight { get; set; }

        public override string ToString()
        {
            return $"There is a {Type}, {Length} cm. long, " +
                $"and {Weight} gr. in weight.";
        }
    }
}
