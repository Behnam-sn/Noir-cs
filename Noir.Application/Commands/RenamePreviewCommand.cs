namespace Noir.Application.Commands;

public class RenamePreviewCommand
{
    public string? Path { get; }

    public RenamePreviewCommand(string? path)
    {
        Path = path;
    }
}
