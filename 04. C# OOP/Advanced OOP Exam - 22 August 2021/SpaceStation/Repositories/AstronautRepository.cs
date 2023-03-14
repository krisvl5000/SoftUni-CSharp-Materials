using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }

        private List<IAstronaut> models;

        public IReadOnlyCollection<IAstronaut> Models => models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            models.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            var modelToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (modelToRemove == null)
            {
                return false;
            }

            models.Remove(modelToRemove);
            return true;
        }

        public IAstronaut FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
