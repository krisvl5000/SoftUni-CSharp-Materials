using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] cmdArgs)
        {
            string type = cmdArgs[0];
            string name = cmdArgs[1];
            double weight = double.Parse(cmdArgs[2]);
            string fourthArg = cmdArgs[3];

            IAnimal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(fourthArg));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(fourthArg));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, fourthArg);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, fourthArg);
            }
            else if (type == "Cat")
            {
                string breed = cmdArgs[4];
                animal = new Cat(name, weight, fourthArg, breed);
            }
            else if (type == "Tiger")
            {
                string breed = cmdArgs[4];
                animal = new Tiger(name, weight, fourthArg, breed);
            }
            else
            {
                throw new InvalidAnimalTypeException();
            }

            return animal;
        }
    }
}
