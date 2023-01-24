using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Car
    {
        private string name;
        private int speed;

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public string Name { get; set; }

        public int Speed { get; set; }
    }
}
