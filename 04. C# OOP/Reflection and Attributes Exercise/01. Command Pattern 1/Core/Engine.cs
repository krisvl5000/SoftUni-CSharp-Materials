using _01._Command_Pattern_1.Core.Contracts;

namespace _01._Command_Pattern_1.Core;

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
            if (input == null) continue;
            string result = commandInterpreter.Read(input);
            Console.WriteLine(result);
        }
    }
}