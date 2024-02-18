using System.Reflection;

namespace Core.Utils;

public static class ReflectionUtils
{
    public static IEnumerable<Assembly> GetAllAssembly()
    {
        return AppDomain.CurrentDomain.GetAssemblies();
    }
    
    public static IEnumerable<Type> GetAssemblyTypes()
    {
        var types = new List<Type>();
        foreach (var assembly in GetAllAssembly())
        {
            types.AddRange(assembly.GetTypes());
        }

        return types;
    }

    public static void LoadDll(string path)
    {
        Assembly.LoadFrom(path);
    }

    public static void LoadDlls(string dir)
    {
        var directoryInfo = new DirectoryInfo(dir);
        
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
            return;
        }
        
        foreach (var fileInfo in directoryInfo.GetFiles())
        {
            if (fileInfo.Exists && fileInfo.Name.EndsWith(".dll"))
            {
                LoadDll(fileInfo.FullName);
            }
        }
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
        Dictionary<Attribute, Type> dictionary = new ();
        
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

    public static IEnumerable<Type> GetTypeByName(string name)
    {
        var types = new List<Type>();
        foreach (var assembly in GetAllAssembly())
        {
            types.AddRange(assembly.GetTypes().Where(type => type.Name == name));
        }
        return types;
    }
}