using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer,
            IAnimalFactory animalFactory, IFoodFactory foodFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                HandleInput(command);
            }
        }

        private IAnimal BuildAnimalUsingFactory(string command)
        {
            string[] cmdArgs = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IAnimal animal = animalFactory.CreateAnimal(cmdArgs);
            return animal;
        }

        private IFood BuildFoodUsingFactory()
        {
            string[] foodArgs = reader.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            IFood currentFood = foodFactory
                .CreateFood(foodType, foodQuantity);
            return currentFood;
        }

        private void HandleInput(string command)
        {
            try
            {
                IAnimal currentAnimal = BuildAnimalUsingFactory(command);
                IFood currentFood = BuildFoodUsingFactory();

                writer.WriteLine(currentAnimal.ProduceSound());
                currentAnimal.Eat(currentFood);

                animals.Add(currentAnimal);
            }
            catch (InvalidAnimalTypeException iate)
            {
                writer.WriteLine(iate.Message);
            }
            catch (InvalidFoodTypeException ifte)
            {
                writer.WriteLine(ifte.Message);
            }
            catch (FoodNotEdibleException fnee)
            {
                writer.WriteLine(fnee.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void PrintAllAnimals()
        {
            foreach (var item in animals)
            {
                writer.WriteLine(item);
            }
        }
    }
}
