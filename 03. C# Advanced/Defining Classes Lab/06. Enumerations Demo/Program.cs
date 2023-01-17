using System;
using System.Collections.Generic;

namespace Enumerations
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarState carState = CarState.ZaMorgata;

            Console.WriteLine(carState);

            Console.WriteLine((CarState)2);
        }
    }
}