using Noir.Domain;

namespace Noir.Service;

public class MovieRenameService : RenameServiceBase
{
    public MovieRenameService() : base(new MovieProcessor())
    {
    }
}