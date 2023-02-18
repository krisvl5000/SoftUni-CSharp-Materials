using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textilesQueue = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> medicamentsStack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var dict = new Dictionary<string, int>();
            dict.Add("Patch", 30);
            dict.Add("Bandage", 40);
            dict.Add("MedKit", 100);

            var createdItems = new Dictionary<string, int>();

            while (textilesQueue.Count > 0 && medicamentsStack.Count > 0)
            {
                bool itemWasMade = false;

                int textile = textilesQueue.Peek();
                int medicament = medicamentsStack.Peek();

                foreach (var item in dict)
                {
                    if (textile + medicament == item.Value)
                    {
                        if (!createdItems.ContainsKey(item.Key))
                        {
                            createdItems.Add(item.Key, 0);
                        }

                        createdItems[item.Key]++;

                        textilesQueue.Dequeue();
                        medicamentsStack.Pop();
                        itemWasMade = true;
                        continue;
                    }
                }

                if (!itemWasMade)
                if (textile + medicament > 100)
                {
                    if (!createdItems.ContainsKey("MedKit"))
                    {
                        createdItems.Add("MedKit", 0);
                    }

                    createdItems["MedKit"]++;
                    medicamentsStack.Pop();
                    textilesQueue.Dequeue();

                    int remainingValue = textile + medicament - 100;

                    if (medicamentsStack.Count > 0)
                    {
                        medicamentsStack.Push(medicamentsStack.Pop() + remainingValue);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    textilesQueue.Dequeue();
                    medicamentsStack.Push(medicamentsStack.Pop() + 10);
                }
            }

            if (medicamentsStack.Count == 0 && textilesQueue.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else
            {
                if (textilesQueue.Count == 0)
                {
                    Console.WriteLine("Textiles are empty.");
                }
                if (medicamentsStack.Count == 0)
                {
                    Console.WriteLine("Medicaments are empty.");
                }
            }

            var orderedDict = createdItems
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var item in orderedDict)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if (medicamentsStack.Any())
            {
                Console.WriteLine($"Medicaments left: " +
                    $"{String.Join(", ", medicamentsStack)}");
            }

            if (textilesQueue.Any())
            {
                Console.WriteLine($"Textiles left: " +
                    $"{String.Join(", ", textilesQueue)}");
            }
        }
    }
}