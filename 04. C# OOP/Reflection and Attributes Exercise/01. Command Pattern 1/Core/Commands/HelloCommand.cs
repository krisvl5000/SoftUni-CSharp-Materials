using CommandPattern;

namespace _01._Command_Pattern_1.Core.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] input)
            => $"Hello, {input[0]}";
    }
}


