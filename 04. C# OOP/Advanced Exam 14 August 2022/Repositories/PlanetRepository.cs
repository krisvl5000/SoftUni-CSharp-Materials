using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();
        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            var itemToRemove = models.FirstOrDefault(x => x.Name == name);

            if (itemToRemove != null)
            {
                models.Remove(itemToRemove);
                return true;
            }

            return false;
        }
    }
}
