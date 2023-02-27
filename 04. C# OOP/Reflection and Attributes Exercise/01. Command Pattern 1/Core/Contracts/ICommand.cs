namespace _01._Command_Pattern_1.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}