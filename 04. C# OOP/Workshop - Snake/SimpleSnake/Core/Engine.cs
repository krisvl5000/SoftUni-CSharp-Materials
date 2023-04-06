using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSnake.Core.Interfaces;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {
            
        }

        public void Run()
        {
            Wall wall = new Wall(60, 20);

            while (true)
            {
                
            }

            Console.WriteLine();
        }
    }
}
