using Noir.Application.Contracts;
using Noir.Application.Contracts.Commands;

namespace Noir.Application;

public abstract class RenameServiceBase : IRenameService
{
    protected abstract string? GenerateNewFileName(string fileName);

    public IEnumerable<RenameContext> Execute(RenamePreviewCommand command)
    {
        if (!Directory.Exists(command.Path))
        {
            throw new Exception($"'{command.Path}' is not a valid file or directory.");
        }

        var contexts = new List<RenameContext>();
        var files = Directory.EnumerateFiles(command.Path);

        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var newFileName = GenerateNewFileName(fileName);

            if (newFileName is null)
            {
                continue;
            }

            var renameContext = new RenameContext(
                path: command.Path,
                oldName: fileName,
                newName: newFileName);

            contexts.Add(renameContext);
        }

        return contexts;
    }

    public IEnumerable<RenameContext> Execute(RenameCommand command)
    {
        if (!Directory.Exists(command.Path))
        {
            throw new Exception($"'{command.Path}' is not a valid file or directory.");
        }

        var contexts = new List<RenameContext>();
        var files = Directory.EnumerateFiles(command.Path);

        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var newFileName = GenerateNewFileName(fileName);

            if (newFileName is null)
            {
                continue;
            }

            var parentDirectoryName = Path.GetFileNameWithoutExtension(newFileName);
            var parentDirectoryNameWithPath = Path.Combine(command.Path, parentDirectoryName);

            if (!Directory.Exists(parentDirectoryNameWithPath))
            {
                Directory.CreateDirectory(parentDirectoryNameWithPath);
            }

            var newFileNameWithPath = Path.Combine(parentDirectoryNameWithPath, newFileName);
            File.Move(file, newFileNameWithPath);

            var renameContext = new RenameContext(
                path: command.Path,
                oldName: fileName,
                newName: newFileName);

            contexts.Add(renameContext);
        }

        return contexts;
    }
}
