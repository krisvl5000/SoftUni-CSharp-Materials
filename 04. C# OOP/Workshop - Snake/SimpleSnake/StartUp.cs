using System;
using SimpleSnake.Core;
using SimpleSnake.Core.Interfaces;

namespace SimpleSnake
{
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
