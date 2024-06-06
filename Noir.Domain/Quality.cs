namespace Noir.Domain;

public class Quality
{
    public string Type { get; }

    public Quality(string type)
    {
        Type = type;
    }

    public override string ToString()
    {
        return Type;
    }

    public static Quality? Parse(string text)
    {
        return null;
    }
}