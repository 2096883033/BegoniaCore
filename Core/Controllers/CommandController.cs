using System.Reflection;
using System.Text;
using Core.Attributes;
using Core.Commands;
using Core.Interfaces;
using Core.Utils;

namespace Core.Controllers;

public static class CommandController
{
    private static readonly Dictionary<CommandInfo, ICommand> Commands;
    
    static CommandController()
    {
        Commands = LoadCommands();
    }

    private static Dictionary<CommandInfo, ICommand> LoadCommands()
    {
        var commands = new Dictionary<CommandInfo, ICommand>();
        
        foreach (var pair in ReflectionUtils.GetSubTypeWithAttribute(typeof(CommandInfo), typeof(ICommand)))
        {
            if (pair.Key is not CommandInfo commandInfo)
                continue;

            if (!commandInfo.Enable)
                continue;
            
            var obj = Activator.CreateInstance(pair.Value);
            if (obj is not ICommand command)
                continue;
            
            commands.Add(commandInfo, command);
        }

        return commands;
    }
    
    public static void Exec(Dictionary<string, List<string>> argumentDictionary)
    {
        if (!argumentDictionary.TryGetValue("mode", out var modeList))
        {
            new InfoCommand().Run(argumentDictionary);
            return;
        }

        if (modeList.Count < 1)
        {
            Console.WriteLine("Mode is empty!");
        }

        var mode = modeList[0];

        if (Commands.All(pair => pair.Key.Name != mode))
        {
            Console.WriteLine("Command " + mode + " is not exists!");
            return;
        }

        var (commandInfo, command) = Commands.First(pair => pair.Key.Name == mode);
        
        if (commandInfo.Args != null)
        {
            var mustArgs = commandInfo.Args.Where(s => !s.EndsWith('?'));
            var currArgs = argumentDictionary.Keys;

            if (!mustArgs.All(key => currArgs.Contains(key)))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder
                    .Append("Command: ")
                    .Append('-')
                    .Append(commandInfo.Name);
                
                foreach (var arg in commandInfo.Args)
                {
                    stringBuilder
                        .Append(' ')
                        .Append(arg);
                }
                
                Console.WriteLine(stringBuilder.ToString());
                return;
            }
        }

        argumentDictionary.Remove("mode");
        
        command.Run(argumentDictionary);
    }
}