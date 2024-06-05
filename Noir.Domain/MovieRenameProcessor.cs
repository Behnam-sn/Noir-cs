using Noir.Domain.Contracts;

namespace Noir.Domain;

public class MovieRenameProcessor : IProcessor
{
    public RenameContext? Preview(string fileNameWithPath)
    {
        var fileName = Path.GetFileName(fileNameWithPath);
        var movie = Movie.Parse(fileName: fileName);

        if (movie is null)
        {
            return null;
        }

        var newFileName = movie.ToString();
        var path = Path.GetDirectoryName(fileNameWithPath);

        var context = new RenameContext(
            path: path,
            oldName: fileName,
            newName: newFileName);
        return context;
    }

    public RenameContext? Rename(string fileNameWithPath)
    {
        var fileName = Path.GetFileName(fileNameWithPath);
        var movie = Movie.Parse(fileName: fileName);

        if (movie is null)
        {
            return null;
        }

        var newFileName = movie.ToString();
        var parentDirectoryName = Path.GetFileNameWithoutExtension(newFileName);

        var path = Path.GetDirectoryName(fileNameWithPath);
        var parentDirectoryNameWithPath = Path.Combine(path, parentDirectoryName);

        if (!Directory.Exists(parentDirectoryNameWithPath))
        {
            Directory.CreateDirectory(parentDirectoryNameWithPath);
        }

        var newFileNameWithPath = Path.Combine(parentDirectoryNameWithPath, newFileName);
        File.Move(fileNameWithPath, newFileNameWithPath);

        var context = new RenameContext(
            path: path,
            oldName: fileName,
            newName: newFileName);
        return context;
    }
}