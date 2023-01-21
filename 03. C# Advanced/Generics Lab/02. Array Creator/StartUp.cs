using System;
using GenericArrayCreator;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = ArrayCreator.Create(100, 6);

            var texts = ArrayCreator.Create(100, "Ivailo");

        }
    }
}