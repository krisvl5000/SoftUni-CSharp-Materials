namespace CommandPattern
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] input)
            => $"Hello, {input[0]}";
    }
}


