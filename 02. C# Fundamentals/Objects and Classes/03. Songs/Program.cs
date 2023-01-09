using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    public class Song
    {
        public Song(string type, string name, string time)
        {
            Type = type;
            Name = name;
            Time = time;
        }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('_').ToArray();

                string type = input[0];
                string name = input[1];
                string time = input[2];

                Song newSong = new Song(type, name, time);
    
                songs.Add(newSong);
            }

            string whichToPrint = Console.ReadLine();

            if (whichToPrint == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
               List<Song> filteredSongs = songs
                   .FindAll(song => song.Type == whichToPrint);

                foreach (Song song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }

            }

        }
    }
}