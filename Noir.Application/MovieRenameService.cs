using Noir.Domain;

namespace Noir.Application;

public class MovieRenameService : RenameServiceBase
{
    protected override string? GenerateNewFileName(string fileName)
    {
        var movie = Movie.Parse(fileName: fileName);
        return movie?.ToString();
    }
}
