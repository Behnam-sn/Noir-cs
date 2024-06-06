namespace Noir.Domain;

public class EpisodeIndex
{
    public int Number { get; }

    public override string ToString()
    {
        return $"E{Number}";
    }

    public static EpisodeIndex? Parse(string fileName)
    {
        throw new NotImplementedException();
    }
}