using Noir.Domain.Contracts;

namespace Noir.Domain;

public class SeriesRenameProcessor : IProcessor
{
    public RenameContext? Preview(string fileNameWithPath)
    {
        throw new NotImplementedException();
    }

    public RenameContext? Rename(string fileNameWithPath)
    {
        throw new NotImplementedException();
    }
}