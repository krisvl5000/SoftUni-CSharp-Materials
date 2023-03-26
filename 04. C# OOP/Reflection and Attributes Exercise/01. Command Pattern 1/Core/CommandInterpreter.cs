using System.Reflection;
using _01._Command_Pattern_1.Core.Contracts;

namespace _01._Command_Pattern_1.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string input)
        {
            string[] tokens = input.Split();
            string command = tokens[0] + "Command";
            string[] value = tokens.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes()
                .First(x => x.Name == command);

            ICommand instance = Activator.CreateInstance(type) as ICommand;

            return instance.Execute(value);
        }
    }
}
