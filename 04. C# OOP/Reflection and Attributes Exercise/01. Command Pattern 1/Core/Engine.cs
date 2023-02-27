using System.Runtime.CompilerServices;
using System.Xml;

namespace CommandPattern;

public class Engine : IEngine
{
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            string input = Console.ReadLine();
            string result = commandInterpreter.Read(input);
            Console.WriteLine(result);
        }
    }
}