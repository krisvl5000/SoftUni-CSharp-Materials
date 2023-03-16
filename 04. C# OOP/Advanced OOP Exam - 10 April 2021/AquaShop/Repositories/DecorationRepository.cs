    using System;
using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;

    namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;
        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => models.AsReadOnly();

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            var modelToRemove = models.FirstOrDefault(x => x.Equals(models));

            if (modelToRemove == null)
            {
                return false;
            }

            models.Remove(modelToRemove);
            return true;
        }

        public IDecoration FindByType(string type) => models.FirstOrDefault(x => x.GetType().Name == type);
    }
}
