using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> models;

        public SupplementRepository()
        {
            models = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models() => models.AsReadOnly();

        public void AddNew(ISupplement model)
        {
            models.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            var itemToRemove = models.FirstOrDefault(x => x.GetType().Name == typeName); // use typeof if not working

            if (itemToRemove == null)
            {
                return false;
            }

            models.Remove(itemToRemove);
            return true;
        }

        public ISupplement FindByStandard(int interfaceStandard) =>
            models.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
    }
}
