using Noir.Domain.Contracts;

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
            var fileName = Path.GetFileName(file);
            var newFileName = _processor.Process(fileName);

            if (newFileName is null)
            {
                continue;
            }

            contexts.Add(new RenameContext(
                path: path,
                oldName: fileName,
                newName: newFileName));
        }

        return contexts;
    }

    public IEnumerable<RenameContext> Rename(string? path)
    {
        throw new NotImplementedException();
    }
}