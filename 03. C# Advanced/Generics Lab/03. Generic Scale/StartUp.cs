using System;
using GenericScale;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> scale = new EqualityScale<string>("A", "A");

            Console.WriteLine(scale.AreEqual());

        }
    }
}