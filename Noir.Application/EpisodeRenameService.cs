using Noir.Application.Contracts;
using Noir.Domain;

namespace Noir.Application;

public class EpisodeRenameService : RenameServiceBase
{
    protected override RenameContext? GenerateRenameContext(string fileName)
    {
        var episode = Episode.Parse(fileName: fileName);

        if (episode is null)
        {
            return null;
        }

        return new RenameContext(
            parentDirectoryName: $"Season {episode.EpisodeIndex.Season}",
            oldName: fileName,
            newName: episode.ToString());
    }
}
