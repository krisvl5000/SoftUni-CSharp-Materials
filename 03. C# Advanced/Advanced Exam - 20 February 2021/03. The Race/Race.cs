using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRace
{
    public class Race
    {
        private string name;
        private int capacity;
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                Racer racerToRemove = data.First(x => x.Name == name);
                data.Remove(racerToRemove);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).First();
        }

        public Racer GetRacer(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                return data.First(x => x.Name == name);
            }

            return null;
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString();
        }

    }
}
