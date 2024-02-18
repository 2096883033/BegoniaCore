namespace Core.Entities;

public class Properties(
    Dictionary<string, string> pairs
)
{
    public readonly Dictionary<string, string> Pairs = pairs;
}