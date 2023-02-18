
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKindergarted
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }

        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] childNameArgs = childFullName.Split(" ");
            string firstName = childNameArgs[0];
            string lastName = childNameArgs[1];

            if (Registry.Any(x => x.FirstName == firstName &&
                x.LastName == lastName))
            {
                Child childToRemove = Registry
                    .First(x => x.FirstName == firstName &&
                     x.LastName == lastName);
                Registry.Remove(childToRemove);
                return true;
            }

            return false;
        }

        public Child GetChild(string childFullName)
        {
            string[] childNameArgs = childFullName.Split(" ");
            string firstName = childNameArgs[0];
            string lastName = childNameArgs[1];

            Child childToReturn = Registry
                    .FirstOrDefault(x => x.FirstName == firstName &&
                     x.LastName == lastName);

            return childToReturn;
        }

        public string RegistryReport()
        {
            Registry = Registry
                 .OrderByDescending(x => x.Age)
                 .ThenBy(x => x.LastName)
                 .ThenBy(x => x.FirstName).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry)
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
