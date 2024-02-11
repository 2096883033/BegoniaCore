namespace Core.Interfaces;

public interface ICommand
{
    void Run(Dictionary<string, List<string>> argumentDictionary);
}