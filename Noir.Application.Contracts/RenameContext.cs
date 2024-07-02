namespace Noir.Application.Contracts;

public class RenameContext
{
    public RenameContext(string path, string oldName, string newName)
    {
        Path = path;
        OldName = oldName;
        NewName = newName;
    }

    public string Path { get; }
    public string OldName { get; }
    public string NewName { get; }
}
