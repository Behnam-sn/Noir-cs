namespace Noir.Domain;

public class EpisodeTitle : Title
{
    public EpisodeTitle(string name) : base(name)
    {
    }

    public static EpisodeTitle Parse(string fileName, Season season, EpisodeIndex episode, Quality? quality)
    {
        var index = $"{season}{episode}";
        var i = fileName.IndexOf(index);
        var name = fileName[..i];
        return new EpisodeTitle(name);
    }
}