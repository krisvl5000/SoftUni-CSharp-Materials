using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleArgs = Console.ReadLine().Split(", ").ToArray();

            string title = articleArgs[0];
            string content = articleArgs[1];
            string author = articleArgs[2];

            Article article = new Article(title, content, author);

            int changesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < changesCount; i++)
            {
                string[] commands = Console.ReadLine().Split(": ").ToArray();
                
                string command = commands[0];
                string change = commands[1];

                if (command == "Edit")
                {
                    article.Edit(change);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(change);
                }
                else if (command == "Rename")
                {
                    article.Rename(change);
                }
            }

            Console.WriteLine(article);

        }
    }
}