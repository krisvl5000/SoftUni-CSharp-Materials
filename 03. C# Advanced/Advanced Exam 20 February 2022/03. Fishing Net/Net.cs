using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public List<Fish> Fish { get { return this.fish; }  }

        public int Count => fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.Type))
            {
                return "Invalid fish.";
            }
            if (this.fish.Count == Capacity)
            {
                return "Fishing net is full";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.Type} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fishToRealease = fish.FirstOrDefault(x => x.Weight == weight);

            if (fishToRealease == null)
            {
                return false;
            }

            fish.Remove(fishToRealease);

            return true;
        }

        public Fish GetFish(string fishType)
        {
            return fish.FirstOrDefault(x => x.Type == fishType);
        }

        public Fish GetBiggestFish()
        {
            return fish.OrderByDescending(x => x.Length).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}:");

            foreach (var item in fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
