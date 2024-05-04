using Noir.Domain;

namespace Noir.Service;

public class MovieRenameService
{
    private readonly MovieProcessor movieProcessor;

    public MovieRenameService()
    {
        movieProcessor = new MovieProcessor();
    }

    public IEnumerable<RenameContext> Preview(string? path)
    {
        if (!Directory.Exists(path))
        {
            throw new Exception($"'{path}' is not a valid file or directory.");
        }

        var result = new List<RenameContext>();

        var fileEntries = Directory.GetFiles(path);
        foreach (var fileName in fileEntries)
        {
            var renameContext = new RenameContext(
                path: path,
                oldName: Path.GetFileName(fileName),
                newName: movieProcessor.Process(fileName: Path.GetFileName(fileName)));
            result.Add(renameContext);
        }

        return result;
    }
}