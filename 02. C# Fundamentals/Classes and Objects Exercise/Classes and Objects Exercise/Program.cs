using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<string> phrases = new List<string>();
            phrases.Add("Excellent product.");
            phrases.Add("Such a great product.");
            phrases.Add("I always use that product.");
            phrases.Add("Best product of its category.");
            phrases.Add("Exceptional product.");
            phrases.Add("I can't live without this product.");

            List<String> events = new List<String>();
            events.Add("Now I feel good.");
            events.Add("I have succeeded with this product.");
            events.Add("Makes miracles. I am happy with the results.");
            events.Add("I cannot believe but now I feel awesome.");
            events.Add("Try it yourself, I am very satisfied.");
            events.Add("I feel great!");

            List<string> authors = new List<string>();
            authors.Add("Diana");
            authors.Add("Petya");
            authors.Add("Stella");
            authors.Add("Elena");
            authors.Add("Katya");
            authors.Add("Iva");
            authors.Add("Annie");
            authors.Add("Eva");
            
            List<string> cities = new List<string>();
            cities.Add("Burgas");
            cities.Add("Sofia");
            cities.Add("Plovdiv");
            cities.Add("Varna");
            cities.Add("Ruse");

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int randomPhraseIndex = random.Next(phrases.Count);
                int randomEventIndex = random.Next(events.Count);
                int randomAuthorIndex = random.Next(authors.Count);
                int randomCitiesIndex = random.Next(cities.Count);


                Console.WriteLine($"{phrases[randomPhraseIndex]} " +
                    $"{events[randomEventIndex]} " +
                    $"{authors[randomAuthorIndex]} - " +
                    $"{cities[randomCitiesIndex]}.");
            }

        }
    }
}