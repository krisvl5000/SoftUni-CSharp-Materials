using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            return $"Make: {this.Make}" +
                $"\nModel: {this.Model}" +
                $"\nHorsePower: {this.HorsePower}" +
                $"\nRegistrationNumber: {this.RegistrationNumber}";
        }
    }
}
