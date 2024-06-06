namespace Noir.Domain;

public class EpisodeTitle : Title
{
    public EpisodeTitle(string name) : base(name)
    {
    }

    public static EpisodeTitle Parse()
    {
        throw new NotImplementedException();
    }
}