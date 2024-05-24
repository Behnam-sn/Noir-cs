using Noir.Domain;

namespace Noir.Service;

public class SeriesRenameService : RenameServiceBase
{
    public SeriesRenameService() : base(new SeriesProcessor())
    {
    }

    public IEnumerable<RenameContext> Rename(string? path)
    {
        throw new NotImplementedException();
    }
}