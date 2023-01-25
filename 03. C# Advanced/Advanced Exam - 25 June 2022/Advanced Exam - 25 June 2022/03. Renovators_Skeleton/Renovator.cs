using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired = false;

        public Renovator(string name, string type, double rate, int days)
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Rate { get; set; }

        public int Days { get; set; }

        public bool Hired { get; set; } = false;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {this.name}");
            sb.AppendLine($"--Specialty: {this.type}");
            sb.AppendLine($"--Rate per day: {this.rate} BGN");
            
            string stringToReturn = sb.ToString();
            return stringToReturn.TrimEnd();
        }
    }
}
