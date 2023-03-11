using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    internal class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();

        public void Add(IWeapon model)
        {
            models.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            var weaponToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (weaponToRemove == null)
            {
                return false;
            }

            models.Remove(weaponToRemove);
            return true;
        }

        public IWeapon FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
