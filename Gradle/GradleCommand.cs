using Core.Attributes;
using Core.Interfaces;

namespace Gradle;

[CommandInfo("Gradle")]
public class GradleCommand : ICommand
{
    public void Run(Dictionary<string, List<string>> argumentDictionary)
    {
        Console.WriteLine("Gradle support plugin: 0.0.1");
    }
}