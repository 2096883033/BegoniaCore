using System.Reflection;

namespace Core.Utils;

public static class ReflectionUtils
{
    public static IEnumerable<Type> GetAssemblyTypes()
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetTypes();
    }

    public static IEnumerable<Type> GetAllClass()
    {
        return GetAssemblyTypes().Where(type => type.IsClass);
    }
    
    public static IEnumerable<Type> GetSubType(Type type)
    {
        var types = GetAllClass();
        return types.Where(type.IsAssignableFrom);
    }

    public static Dictionary<Attribute, Type> GetSubTypeWithAttribute(Type attribute, Type subType)
    {
        Dictionary<Attribute, Type> dictionary = new();
        
        var types = GetSubType(subType);
        
        foreach (var type in types)
        {
            var attributeType = type.GetCustomAttribute(attribute);
            if (attributeType == null)
                continue;
            
            dictionary.Add(attributeType, type);
        }

        return dictionary;
    }
}