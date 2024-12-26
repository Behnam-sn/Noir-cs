using Noir.Application.Shared.Abstractions;
using Noir.Application.Shared.Responses;
using Noir.Domain.Episodes;

namespace Noir.Application.Episodes;

public sealed class EpisodeRenameService : RenameServiceBase
{
    protected override RenameContext? GenerateRenameContext(string fileName)
    {
        var episode = Episode.Parse(fileName);

        if (episode is null)
        {
            return null;
        }

        return new RenameContext(
            ParentDirectoryName: $"Season {episode.Index.Season}",
            OldName: fileName,
            NewName: episode.ToString()
        );
    }
}
