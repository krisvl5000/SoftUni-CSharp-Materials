using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }

        public string Name { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }

        public override string ToString()
        {
            return $"{this.Name} -> Composer: " +
                    $"{this.Composer}, Key: {this.Key}"; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Piece> list = new List<Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] pieceArgs = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string name = pieceArgs[0];
                string composer = pieceArgs[1];
                string key = pieceArgs[2];

                Piece newPiece = new Piece(name, composer, key);
                list.Add(newPiece);
            }

            string[] input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Stop")
            {
                string command = input[0];

                if (command == "Add")
                {
                    string piece = input[1];
                    string composer = input[2];
                    string key = input[3];

                    if (!list.Any(x => x.Name == piece))
                    {
                        Piece newPiece = new Piece(piece, composer, key);
                        list.Add(newPiece);

                        Console.WriteLine($"{piece} by {composer} in {key} " +
                            $"added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    
                }
                else if (command == "Remove")
                {
                    string piece = input[1];

                    if (list.Any(x => x.Name == piece))
                    {
                        Piece pieceToRemove = list.Find(x => x.Name == piece);
                        list.Remove(pieceToRemove);

                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist " +
                            $"in the collection.");
                    }
                    
                }
                else if (command == "ChangeKey")
                {
                    string piece = input[1];
                    string newKey = input[2];

                    if (list.Any(x => x.Name == piece))
                    {
                        Piece pieceToChange = list.Find(x => x.Name == piece);
                        pieceToChange.Key = newKey;

                        Console.WriteLine($"Changed the key of {piece} to " +
                            $"{newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist " +
                            $"in the collection.");
                    }
                }

                input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var piece in list)
            {
                Console.WriteLine(piece);
            }

        }
    }
}