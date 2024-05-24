namespace Noir.Service.Contracts;

public interface IRenameService
{
    IEnumerable<RenameContext> Preview(string? path);

    IEnumerable<RenameContext> Rename(string? path);
}