namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class TranslatorInfo : Attribute
{
    public string Name { get; }
    public bool Enable { get; } = true;

    public TranslatorInfo(string name)
    {
        Name = name;
    }

    public TranslatorInfo(string name, bool enable)
    {
        Name = name;
        Enable = enable;
    }
}