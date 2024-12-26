namespace Noir.Application.Shared.Responses;

public sealed record RenameContext(string ParentDirectoryName, string OldName, string NewName);
