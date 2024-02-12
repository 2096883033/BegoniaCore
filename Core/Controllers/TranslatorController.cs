using Core.Attributes;
using Core.Interfaces;
using Core.Utils;

namespace Core.Controllers;

public static class TranslatorController
{
    private static readonly Dictionary<TranslatorInfo, ITranslator> Ttranslators;

    static TranslatorController()
    {
        Ttranslators = LoadTranslators();
    }

    private static Dictionary<TranslatorInfo, ITranslator> LoadTranslators()
    {
        Dictionary<TranslatorInfo, ITranslator> translators = new();
        
        foreach (var pair in ReflectionUtils.GetSubTypeWithAttribute(typeof(TranslatorInfo), typeof(ITranslator)))
        {
            if (pair.Key is not TranslatorInfo translatorInfo)
                continue;

            if (!translatorInfo.Enable)
                continue;
            
            var obj = Activator.CreateInstance(pair.Value);
            if (obj is not ITranslator translator)
                continue;
            
            translators.Add(translatorInfo, translator);
        }

        return translators;
    }

    public static ITranslator? GetTranslatorByName(string name)
    {
        var pairs = Ttranslators.Where(pair => pair.Key.Name == name).ToList();
        return pairs.Count == 0 ? null : pairs.First().Value;
    }
}