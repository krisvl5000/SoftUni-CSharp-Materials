using CommandPattern;

namespace _01._Command_Pattern_1.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] input)
        {
            Environment.Exit(0);
            return null;
        }
    }
}

