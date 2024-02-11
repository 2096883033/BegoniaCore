namespace Core.Utils;

public class ArgumentUtils
{
    public static Dictionary<string, List<string>> Parse(IEnumerable<string> args)
    {
        var dictionary = new Dictionary<string, List<string>>();
        var argList = args.ToList();
        
        for (var i = 0; i < argList.Count; i++)
        {
            var key = argList[i];
            var value = new List<string>();
            
            if (!key.StartsWith('-') || key.Equals(""))
            {
                continue;
            }
            
            while (i + 1 < argList.Count && !argList[i + 1].StartsWith('-'))
            {
                value.Add(argList[i + 1]);
                i++;
            }
            
            dictionary.Add(key.Substring(1, key.Length - 1), value);
        }

        return dictionary;
    }
}