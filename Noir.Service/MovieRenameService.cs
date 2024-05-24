using Noir.Domain;
using Noir.Service.Contracts;

namespace Noir.Service;

public class MovieRenameService : RenameServiceBase
{
    public MovieRenameService() : base(new MovieProcessor())
    {
    }

    public override IEnumerable<RenameContext> Rename(string? path)
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