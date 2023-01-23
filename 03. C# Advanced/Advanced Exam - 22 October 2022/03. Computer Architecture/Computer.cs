using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public List<CPU> Multiprocessor { get; set; }

        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Any(x => x.Brand == brand))
            {
                CPU cpuToRemove = Multiprocessor.First(x => x.Brand == brand);
                Multiprocessor.Remove(cpuToRemove);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            List<CPU> cpuList = new List<CPU>();

            cpuList = Multiprocessor.OrderByDescending(x => x.Frequency).ToList();

            return cpuList.First();
        }

        public CPU GetCPU(string brand)
        {
            if (Multiprocessor.Any(x => x.Brand == brand))
            {
                return Multiprocessor.First(x => x.Brand == brand);
            }

            return null;
        }

        public string Report()
        {
            return String.Join("\n", Multiprocessor);
        }
    }
}
