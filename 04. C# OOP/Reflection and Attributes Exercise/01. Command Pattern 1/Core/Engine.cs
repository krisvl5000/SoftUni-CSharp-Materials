using System.Runtime.CompilerServices;
using System.Xml;
using _01._Command_Pattern_1.Core.Contracts;

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