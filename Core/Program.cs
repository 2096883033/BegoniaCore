using Core.Controllers;
using Core.Utils;

namespace Core;

class Program
{
    private static void Main(string[] args)
    {
        ReflectionUtils.LoadDlls("./");
        
        CommandController.LoadCommands();
        TranslatorController.LoadTranslators();
        
        var argumentDictionary = ArgumentUtils.Parse(args);
        CommandController.Exec(argumentDictionary);
    }
}