namespace Core.Interfaces;

public interface ITranslator
{
    string Translate(Dictionary<string, string> keywordDictionary);
}