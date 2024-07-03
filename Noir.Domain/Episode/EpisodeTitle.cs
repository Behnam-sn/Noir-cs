namespace Noir.Domain.Episode;

public class EpisodeTitle : Title
{
    public EpisodeTitle(string name) : base(name)
    {
    }

    public static EpisodeTitle Parse(string fileName, EpisodeIndex episodeIndex, Quality? quality)
    {
        var index = fileName.IndexOf(episodeIndex.CurrentFormat, StringComparison.CurrentCultureIgnoreCase);
        var name = fileName[..index];
        return new EpisodeTitle(name);
    }
}
