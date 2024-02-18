namespace Gradle.Entities;

public class ScriptValue(
    List<ScriptBlock> blocks,
    List<string> lines
)
{
    public readonly List<ScriptBlock> Blocks = blocks;
    public readonly List<string> Lines = lines;
}