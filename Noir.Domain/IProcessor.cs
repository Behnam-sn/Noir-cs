namespace Noir.Domain;

public interface IProcessor
{
    string Process(string fileName);
}
