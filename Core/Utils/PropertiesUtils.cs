using Core.Entities;

namespace Core.Utils;

public static class PropertiesUtils
{
    
    public static Properties Parse(FileInfo fileInfo)
    {
        var pairs = new Dictionary<string, string>();
        var properties = new Properties(pairs);
        
        foreach (var line in File.ReadLines(fileInfo.FullName))
        {
            if (line.StartsWith('#') || line.StartsWith('!'))
                continue;
            
            if (line.EndsWith(';'))
            {
                foreach (var item in line.Split(';'))
                {
                    AddItem(pairs, item);
                }
            }
            else
            {
                AddItem(pairs, line);
            }
        }

        return properties;
    }

    private static void AddItem(IDictionary<string, string> pairs, string line)
    {
        var strings = line.Split('=');

        if (strings.Length < 2)
            return;

        var key = strings[0];
        var value = strings[1];

        if (key.EndsWith(' '))
            key = key[..^1];
        
        if (value.StartsWith(' '))
            value = value[1..value.Length];
        
        pairs.Add(key, value);
    }
}