namespace Noir.Application.Contracts.Commands;

public class RenameCommand
{
    public string? Path { get; }

    public RenameCommand(string? path)
    {
        Path = path;
    }
}
