namespace Noir.Domain.Contracts;

public interface IProcessor
{
    string? Process(string fileName);
}