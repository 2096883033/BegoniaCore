namespace Gradle.Entities;

public class ScriptBlock(
    string name,
    List<ScriptBlock> blocks,
    List<string> line
)
{
    public readonly string Name = name;
    public readonly List<ScriptBlock> Blocks = blocks;
    public readonly List<string> Lines = line;
}