using Core.Executors;
using Core.Utils;

namespace Core;

class Program
{
    private static void Main(string[] args)
    {
        var argumentDictionary = ArgumentUtils.Parse(args);
        CommandExecutor.Exec(argumentDictionary);
    }
}