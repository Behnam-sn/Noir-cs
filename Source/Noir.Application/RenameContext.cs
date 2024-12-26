namespace Noir.Application;

public class RenameContext
{
    public RenameContext(string parentDirectoryName, string oldName, string newName)
    {
        ParentDirectoryName = parentDirectoryName;
        OldName = oldName;
        NewName = newName;
    }

    public string ParentDirectoryName { get; }
    public string OldName { get; }
    public string NewName { get; }
}
