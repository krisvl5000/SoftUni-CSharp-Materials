using System;

namespace _01._Hello_Softuni
{
    public class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }

        public string Suit { get; set; }

        public override string ToString()
        {
            switch (Suit)
            {
                case "S":
                    Suit = "\u2660";
                        break;
                case "H":
                    Suit = "\u2665";
                    break;
                case "D":
                    Suit = "\u2666";
                    break;
                case "C":
                    Suit = "\u2663";
                    break;
            }
            return $"[{Face}{Suit}]";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            List<string> acceptableFaces = new List<string>()
            {
                "2", 
                "3", 
                "4", 
                "5", 
                "6", 
                "7", 
                "8", 
                "9", 
                "10", 
                "J", 
                "Q", 
                "K", 
                "A"
            };

            List<string> acceptableSuits = new List<string>()
            {
                "S",
                "H",
                "D",
                "C"
            };

            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] cardArgs = input[i].Split(" ");

                string face = cardArgs[0];
                string suit = cardArgs[1];

                try
                {
                    if (acceptableFaces.Any(x => x == face) && 
                        acceptableSuits.Any(x => x == suit))
                    {
                        Card newCard = new Card(face, suit);
                        cards.Add(newCard);
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(String.Join(" ", cards));

        }
    }
}