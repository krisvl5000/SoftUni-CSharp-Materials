using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        private List<IPlanet> models;

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            var modelToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (modelToRemove == null)
            {
                return false;
            }

            models.Remove(modelToRemove);
            return true;
        }

        public IPlanet FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
