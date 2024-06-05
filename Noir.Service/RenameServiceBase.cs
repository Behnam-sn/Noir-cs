using Noir.Domain.Contracts;
using Noir.Service.Contracts;

namespace Noir.Service;

public abstract class RenameServiceBase : IRenameService
{
    protected readonly IProcessor _processor;

    protected RenameServiceBase(IProcessor processor)
    {
        _processor = processor;
    }

    public IEnumerable<RenameContext> Preview(string? path)
    {
        if (!Directory.Exists(path))
        {
            throw new Exception($"'{path}' is not a valid file or directory.");
        }

        var contexts = new List<RenameContext>();
        var files = Directory.EnumerateFiles(path);

        foreach (var file in files)
        {
            var renameContext = _processor.Preview(fileNameWithPath: file);

            if (renameContext is null)
            {
                continue;
            }

            contexts.Add(renameContext);
        }

        return contexts;
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
            var renameContext = _processor.Rename(fileNameWithPath: file);

            if (renameContext is null)
            {
                continue;
            }

            contexts.Add(renameContext);
        }

        return contexts;
    }
}