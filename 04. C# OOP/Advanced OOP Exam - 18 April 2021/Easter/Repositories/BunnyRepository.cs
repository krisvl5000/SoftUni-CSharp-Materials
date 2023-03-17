using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => models.AsReadOnly();

        public void Add(IBunny model)
        {
            models.Add(model);
        }

        public bool Remove(IBunny model)
        {
            if (models.All(x => x.Name != model.Name))
            {
                return false;
            }

            models.Remove(model);
            return true;
        }

        public IBunny FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
