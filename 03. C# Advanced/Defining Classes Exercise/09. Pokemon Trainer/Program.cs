using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainersList = new List<Trainer>();

            string[] cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "Tournament")
            {
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                if (!trainersList.Any(x => x.Name == trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainersList.Add(trainer);

                    Pokemon pokemon = new Pokemon
                    (pokemonName, pokemonElement, pokemonHealth);

                    trainer.List.Add(pokemon);
                }
                else
                {
                    Trainer trainer = trainersList
                        .FirstOrDefault(x => x.Name == trainerName);

                    Pokemon pokemon = new Pokemon
                    (pokemonName, pokemonElement, pokemonHealth);

                    trainer.List.Add(pokemon);
                }

                cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (command == "Fire")
                {
                    HasSuchPokemon(command, trainersList);
                }
                else if (command == "Water")
                {
                    HasSuchPokemon(command, trainersList);
                }
                else if (command == "Electricity")
                {
                    HasSuchPokemon(command, trainersList);
                }
            }

            trainersList = trainersList
                .OrderByDescending(x => x.NumberOfBadges)
                .ToList();

            foreach (var trainer in trainersList)
            {
                Console.WriteLine(trainer);
            }
        }

        static void HasSuchPokemon(string command, List<Trainer> trainersList)
        {
            foreach (var trainer in trainersList)
            {
                if (trainer.List.Any(x => x.Element == command))
                {
                    trainer.NumberOfBadges++;
                }
                else
                {
                    List<Pokemon> pokemonToRemove = new List<Pokemon>();

                    foreach (var pokemon in trainer.List)
                    {
                        pokemon.Health -= 10;

                        if (pokemon.Health <= 0)
                        {
                            pokemonToRemove.Add(pokemon);
                        }
                    }

                    foreach (var pokemon in pokemonToRemove)
                    {
                        trainer.List.Remove(pokemon);
                    }
                }
            }
        }
    }
}