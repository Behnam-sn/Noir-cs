using Noir.Domain;

namespace Noir.Service;

public class MovieRenameService
{
    private readonly MovieProcessor _processor = new();

    public IEnumerable<RenameContext> Preview(string? path)
    {
        if (!Directory.Exists(path))
        {
            throw new Exception($"'{path}' is not a valid file or directory.");
        }

        var fileEntries = Directory.GetFiles(path);
        return fileEntries.Select(fileName => new RenameContext(
                path: path,
                oldName: Path.GetFileName(fileName),
                newName: _processor.Process(fileName: Path.GetFileName(fileName))))
            .ToList();
    }
}