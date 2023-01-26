using System;

namespace Shadowing
{
    public class Program
    {
        static void Main(string[] args)
        {
            //How to avoid confusion with variables when using inheritance
            Child c = new Child();
            c.Add(1);

            c.Hello();
        }
    }

    public class Parent
    {
        public int number = 5;

        public void Hello()
        {
            Console.WriteLine("Hello from Parent");
        }
    }

    public class Child : Parent
    {
        public int number = 8; // When this is missing, it print 5, because it takes the 
        // number from the parent class. When we add this line, shadowing occurrs, and we print 8.
        // If we put a parameter "number" int the brackets, it points to the number,
        // coming from main.
        public void Add(int number)
        {
            Console.WriteLine($"Param {number}"); // this points to the parameter
            Console.WriteLine($"Child {this.number}"); // this point to the instance in the class
            Console.WriteLine($"Parent {base.number}"); // this points to the instance in the base
        }

        public void Hello()
        {
            base.Hello(); // This calls the method from the parent
            Console.WriteLine("Hello from Child");
        }
    }
}