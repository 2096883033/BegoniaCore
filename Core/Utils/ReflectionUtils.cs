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
}