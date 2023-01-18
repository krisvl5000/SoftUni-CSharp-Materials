using System;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            var objectList = new ObjectList<int>(16);

            objectList.Add(1000);
            objectList.Add(2000);

            var first = (int)objectList.Get(1);

            Console.WriteLine(first);

        }
    }
}