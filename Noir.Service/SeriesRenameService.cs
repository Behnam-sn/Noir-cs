using Noir.Domain;

namespace Noir.Service;

public class SeriesRenameService : RenameServiceBase
{
    public SeriesRenameService() : base(new SeriesRenameProcessor())
    {
    }
}