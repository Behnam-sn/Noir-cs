namespace Noir.Domain;

public class EpisodeIndex
{
    public int Season { get; }
    public int Episode { get; }

    public override string ToString()
    {
        return $"S{Season}E{Episode}";
    }

    public static EpisodeIndex? Parse(string fileName)
    {
        throw new NotImplementedException();
    }
}