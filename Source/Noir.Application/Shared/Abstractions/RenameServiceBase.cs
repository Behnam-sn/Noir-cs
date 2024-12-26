using Noir.Application.Shared.Commands;
using Noir.Application.Shared.Interfaces;
using Noir.Application.Shared.Queries;
using Noir.Application.Shared.Responses;

namespace Noir.Application.Shared.Abstractions;

public abstract class RenameServiceBase : IRenameService
{
    protected abstract RenameContext? GenerateRenameContext(string fileName);

    public IEnumerable<RenameContext> Execute(RenamePreviewQuery command)
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
            var renameContext = GenerateRenameContext(fileName);

            if (renameContext is null)
            {
                continue;
            }

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
            var renameContext = GenerateRenameContext(fileName);

            if (renameContext is null)
            {
                continue;
            }

            var parentDirectory = Path.Combine(command.Path, renameContext.ParentDirectoryName);

            if (!Directory.Exists(parentDirectory))
            {
                Directory.CreateDirectory(parentDirectory);
            }

            var newFileName = Path.Combine(parentDirectory, renameContext.NewName);
            File.Move(file, newFileName);

            contexts.Add(renameContext);
        }

        return contexts;
    }
}
