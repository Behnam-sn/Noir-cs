using Noir.Application.Contracts;
using Noir.Domain.Movies;

namespace Noir.Application;

public class MovieRenameService : RenameServiceBase
{
    protected override RenameContext? GenerateRenameContext(string fileName)
    {
        var movie = Movie.Parse(fileName: fileName);

        if (movie is null)
        {
            return null;
        }

        return new RenameContext(
            parentDirectoryName: movie.Title.Name,
            oldName: fileName,
            newName: movie.ToString());
    }
}
