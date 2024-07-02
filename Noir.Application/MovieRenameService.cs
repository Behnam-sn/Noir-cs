using Noir.Domain;

namespace Noir.Application;

public class MovieRenameService : RenameServiceBase
{
    protected override string? GenerateNewFileName(string fileName)
    {
        var movie = Movie.Parse(fileName: fileName);

        if (movie is null)
        {
            return null;
        }

        return movie.ToString();
    }
}
