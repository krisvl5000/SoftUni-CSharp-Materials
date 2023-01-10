using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Hero
    {
        public Hero(string name, int hP, int mP)
        {
            Name = name;
            HP = hP;
            MP = mP;
        }

        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> list = new List<Hero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroArgs = Console.ReadLine().Split();

                string name = heroArgs[0];
                int HP = int.Parse(heroArgs[1]);
                int MP = int.Parse(heroArgs[2]);

                Hero newHero = new Hero(name, HP, MP);
                list.Add(newHero);
            }

            string[] input = Console.ReadLine().Split(" - ");

            while (input[0] != "End")
            {
                string command = input[0];
                string heroName = input[1];

                Hero hero = list.First(x => x.Name == heroName);

                if (command == "CastSpell")
                {
                    int mpNeeded = int.Parse(input[2]);
                    string spellName = input[3];

                    if (hero.MP >= mpNeeded)
                    {
                        hero.MP -= mpNeeded;

                        Console.WriteLine($"{hero.Name} has successfully cast " +
                            $"{spellName} and now has {hero.MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} does not have enough MP " +
                            $"to cast {spellName}!");
                    }    
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(input[2]);
                    string attacker =  input[3];

                    hero.HP -= damage;

                    if (hero.HP > 0)
                    {
                        Console.WriteLine($"{hero.Name} was hit for {damage} HP " +
                            $"by {attacker} and now has {hero.HP} HP left!");
                    }
                    else
                    {
                        list.Remove(hero);
                        Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                    }

                }   
                else if (command == "Recharge")
                {
                    int amount = int.Parse(input[2]);

                    if (hero.MP + amount > 200)
                    {
                        int counter = 0;
                        while (true)
                        {
                            if (amount == 0 || hero.MP == 200)
                            {
                                break;
                            }

                            amount--;
                            hero.MP++;
                            counter++;
                        }

                        Console.WriteLine($"{hero.Name} recharged for {counter} MP!");
                    }
                    else
                    {
                        hero.MP += amount;
                        Console.WriteLine($"{hero.Name} recharged for {amount} MP!");
                    }
                }
                else if (command == "Heal")
                {
                    int amount = int.Parse(input[2]);

                    if (hero.HP + amount > 100)
                    {
                        int counter = 0;
                        while (true)
                        {
                            if (amount == 0 || hero.HP == 100)
                            {
                                break;
                            }

                            amount--;
                            hero.HP++;
                            counter++;
                        }

                        Console.WriteLine($"{hero.Name} healed for {counter} HP!");
                    }
                    else
                    {
                        hero.HP += amount;
                        Console.WriteLine($"{hero.Name} healed for {amount} HP!");
                    }
                }

                input = Console.ReadLine().Split(" - ");
            }

            foreach (var hero in list)
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.HP}");
                Console.WriteLine($"  MP: {hero.MP}");
            }

        }
    }
}