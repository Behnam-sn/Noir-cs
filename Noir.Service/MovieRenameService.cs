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
        var files = Directory.EnumerateFiles(path);

        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var newFileName = _processor.Process(fileName: fileName);

            if (newFileName is null)
            {
                continue;
            }

            var directoryName = Path.GetFileNameWithoutExtension(newFileName);
            var directoryPath = Path.Combine(path, directoryName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var newFilePath = Path.Combine(directoryPath, newFileName);
            File.Move(file, newFilePath);

            contexts.Add(new RenameContext(
                path: path,
                oldName: fileName,
                newName: newFileName));
        }

        return contexts;
    }
}