namespace Noir.Domain;

internal interface IVideoFile : IFile
{
    string? Quality { get; }
}