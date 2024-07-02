namespace Noir.Application.Contracts.Commands;

public class RenamePreviewCommand
{
    public string? Path { get; }

    public RenamePreviewCommand(string? path)
    {
        Path = path;
    }
}
