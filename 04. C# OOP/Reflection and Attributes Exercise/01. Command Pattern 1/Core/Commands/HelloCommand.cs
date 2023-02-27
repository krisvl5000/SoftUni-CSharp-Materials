using System.Security.Cryptography.X509Certificates;

namespace CommandPattern
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] input)
            => $"Hello, {input[0]}";
    }
}


