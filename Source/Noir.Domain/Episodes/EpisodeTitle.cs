using Noir.Domain.Shared;

namespace Noir.Domain.Episodes;

public sealed class EpisodeTitle : Title
{
    public EpisodeTitle(string name) : base(name)
    {
    }

    public static EpisodeTitle Parse(string fileName, EpisodeIndex episodeIndex, Year? year, Quality? quality)
    {
        var indexes = new List<int>
        {
            fileName.IndexOf(episodeIndex.CurrentFormat, StringComparison.CurrentCultureIgnoreCase)
        };

        if (year != null)
        {
            indexes.Add(fileName.IndexOf(year.Numbers, StringComparison.CurrentCultureIgnoreCase));
        }

        if (quality != null)
        {
            indexes.Add(fileName.IndexOf(quality.Type, StringComparison.CurrentCultureIgnoreCase));
        }

        var name = fileName[..indexes.Min()];
        return new EpisodeTitle(name);
    }
}
