using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRace
{
    public class Racer
    {
        private string name;
        private int age;
        private string county;
        private Car car;

        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public Car Car { get; set; }

        public override string ToString()
        {
            return $"Racer: {this.Name}, {this.Age} ({this.Country})";
        }
    }
}
