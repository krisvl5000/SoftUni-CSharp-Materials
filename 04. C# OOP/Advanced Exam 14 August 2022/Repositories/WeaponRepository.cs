using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name); // might not return the name that is needed
        }

        public bool RemoveItem(string name)
        {
            var itemToRemove = models.FirstOrDefault(x => x.GetType().Name == name);

            if (itemToRemove != null)
            {
                models.Remove(itemToRemove);
                return true;
            }

            return false;
            
        }
    }
}
