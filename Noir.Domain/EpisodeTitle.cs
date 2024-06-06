namespace Noir.Domain;

public class EpisodeTitle : Title
{
    public EpisodeTitle(string name) : base(name)
    {
    }

    public static EpisodeTitle Parse(string fileName, EpisodeIndex index, Quality? quality)
    {
        throw new NotImplementedException();
    }
}