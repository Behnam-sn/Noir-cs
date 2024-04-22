namespace Noir.Domain.Contracts;

public interface IVideoFile : IFile
{
    string? Quality { get; }
}