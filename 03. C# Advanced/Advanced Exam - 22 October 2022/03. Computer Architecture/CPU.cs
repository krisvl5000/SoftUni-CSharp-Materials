using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;

        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get; set; }

        public int Cores { get; set; }

        public double Frequency { get; set; }

        public override string ToString()
        {
            return $"{Brand} CPU:\nCores: {Cores}\nFrequency: {Frequency:F1} GHz";
        }
    }
}
