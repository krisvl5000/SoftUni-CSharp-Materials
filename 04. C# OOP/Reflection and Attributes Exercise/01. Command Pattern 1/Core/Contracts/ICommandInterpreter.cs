namespace CommandPattern
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}