namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandInfo : Attribute
{
    public string Name { get; }
    public string[]? Args { get; }
    public bool Enable { get; } = true;
    
    public CommandInfo(string name)
    {
        Name = name;
    }
    
    public CommandInfo(string name, string[]? args)
    {
        Name = name;
        Args = args;
    }

    public CommandInfo(string name, string[]? args, bool enable)
    {
        Name = name;
        Args = args;
        Enable = enable;
    }
}