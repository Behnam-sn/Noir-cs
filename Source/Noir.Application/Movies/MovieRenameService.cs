using Noir.Application.Shared.Abstractions;
using Noir.Application.Shared.Responses;
using Noir.Domain.Movies;

namespace Noir.Application.Movies;

public sealed class MovieRenameService : RenameServiceBase
{
    protected override RenameContext? GenerateRenameContext(string fileName)
    {
        var movie = Movie.Parse(fileName);

        if (movie is null)
        {
            return null;
        }

        return new RenameContext(
            ParentDirectoryName: movie.Title.Name,
            OldName: fileName,
            NewName: movie.GenerateFileName(withYear: true)
        );
    }
}
