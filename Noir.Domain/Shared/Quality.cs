namespace Noir.Domain.Shared;

public class Quality
{
    private static readonly string[] types =
    [
        "1080",
        "720"
    ];

    public Quality(string type)
    {
        Type = type;
    }

    public string Type { get; }

    public override string ToString()
    {
        return Type;
    }

    public static Quality? Parse(string text)
    {
        foreach (var item in types)
        {
            if (text.Contains(item))
            {
                return new Quality(item);
            }
        }
        return null;
    }
}

