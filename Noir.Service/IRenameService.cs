namespace Noir.Service
{
    public interface IRenameService
    {
        IEnumerable<RenameContext> Preview(string? path);

        IEnumerable<RenameContext> Rename(string? path);
    }
}