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

    public IEnumerable<RenameContext> Rename(string? path)
    {
        if (!Directory.Exists(path))
        {
            throw new Exception($"'{path}' is not a valid file or directory.");
        }

        var contexts = new List<RenameContext>();
        var fileEntries = Directory.GetFiles(path);
        var ak = Directory.EnumerateFiles(path);
        foreach (var file in fileEntries)
        {
            var newName = _processor.Process(fileName: Path.GetFileName(file));
            var newFilePath = Path.Combine(path, newName);

            File.Move(file, newFilePath);

            var context = new RenameContext(
                path: path,
                oldName: Path.GetFileName(file),
                newName: newName);
            contexts.Add(context);
        }

        return contexts;
    }
}