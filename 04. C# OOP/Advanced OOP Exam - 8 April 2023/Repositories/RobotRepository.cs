using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;
        public RobotRepository()
        {
            models = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models() => models.AsReadOnly();

        public void AddNew(IRobot model)
        {
            models.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            var itemToRemove = models.FirstOrDefault(x => x.Model == typeName); // if it does not work, change it to remove by type

            if (itemToRemove == null)
            {
                return false;
            }

            models.Remove(itemToRemove);
            return true;
        }

        public IRobot FindByStandard(int interfaceStandard) =>
            models.FirstOrDefault(x => x.InterfaceStandards.Contains(interfaceStandard));
    }
}
