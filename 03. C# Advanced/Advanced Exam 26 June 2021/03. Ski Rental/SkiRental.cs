using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
       
        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Ski> Data => data;

        public int Count => Data.Count;

        public void Add(Ski ski)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = Data.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);

            if (skiToRemove != null)
            {
                Data.Remove(skiToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ski GetNewestSki()
        {
            Ski newestSki = Data.OrderByDescending(x => x.Year).FirstOrDefault();
            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return Data.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in Data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
