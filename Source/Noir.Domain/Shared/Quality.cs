namespace Noir.Domain.Shared;

public sealed class Quality
{
    private static readonly string[] types =
    [
        "1080",
        "720"
    ];

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

