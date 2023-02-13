using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            this.animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public IReadOnlyCollection<Animal> Animals => animals;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (!string.IsNullOrWhiteSpace(animal.Species))
            {
                if (animal.Diet == "herbivore" || animal.Diet == "carnivore")
                {
                    if (animals.Count < Capacity)
                    {
                        animals.Add(animal);
                        return $"Successfully added {animal.Species} to the zoo.";
                    }

                    return "The zoo is full.";
                }

                return "Invalid animal diet.";
            }

            return "Invalid animal species.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;
            List<Animal> list = animals;

            foreach (Animal animal in list)
            {
                if (animal.Species == species)
                {
                    count++;
                    animals.Remove(animal);
                }
            }

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return animals.Where(x => x.Diet == diet).ToList();
        }

        public Animal  GetAnimalByWeight(double weight)
        {
            return animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (var animal in animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between " +
                $"{minimumLength} and {maximumLength} meters.";
        }
    }
}
