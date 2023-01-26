using System;

namespace Shadowing
{
    public class Program
    {
        static void Main(string[] args)
        {
            //How to avoid confusion with variables when using inheritance
            Child c = new Child();
            c.Add();
        }
    }

    public class Parent
    {
        public int number = 5;
    }

    public class Child : Parent
    {
        public int number = 8; // When this is missing, it print 5, because it takes the 
        // number from the parent class. When we add this line, shadowing occurrs, and we print 8
        public void Add()
        {
            Console.WriteLine(number);
        }
    }
}