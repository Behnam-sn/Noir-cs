using Noir.Domain;

namespace Noir.Application;

public class EpisodeRenameService : RenameServiceBase
{
    protected override string? GenerateNewFileName(string fileName)
    {
        var episode = Episode.Parse(fileName: fileName);

        if (episode is null)
        {
            return null;
        }

        return episode.ToString();
    }
}
