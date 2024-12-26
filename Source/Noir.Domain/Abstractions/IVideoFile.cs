namespace Noir.Domain.Abstractions;

public interface IVideoFile : IFile
{
    string? Quality { get; }
}
