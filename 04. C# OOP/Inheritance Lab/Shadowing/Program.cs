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
        public void Add()
        {
            Console.WriteLine(number);
        }
    }
}