using System.Text;
using Gradle.Entities;

namespace Gradle;

public static class GradleScript
{
    public static void Save(FileInfo fileInfo, ScriptValue scriptValue)
    {
        if (!fileInfo.Exists)
        {
            fileInfo.Create();
        }

        var valueBuilder = new StringBuilder();
        
        foreach (var scriptBlock in scriptValue.Blocks)
            Add(0, scriptBlock);
        
        foreach (var line in scriptValue.Lines)
            valueBuilder.AppendLine(line);

        using var writer = new StreamWriter(fileInfo.FullName);
        writer.WriteLine(valueBuilder.ToString());

        return;
        
        void Add(int level, ScriptBlock scriptBlock)
        {
            AppendLevel();
            
            valueBuilder.AppendLine(scriptBlock.Name + " " + "{");
            
            foreach (var innerScriptBlock in scriptBlock.Blocks)
                Add(level + 1, innerScriptBlock);

            foreach (var line in scriptBlock.Lines)
            {
                AppendLevel(1);
                valueBuilder.AppendLine(line);
            }
            
            AppendLevel();
            valueBuilder.AppendLine("}");
            valueBuilder.AppendLine();
            
            return;
            
            void AppendLevel(int count = 0)
            {
                for (var i = 0; i < level + count; i++)
                    valueBuilder.Append("   ");
            }
        }
    }
}