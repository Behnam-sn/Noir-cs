namespace Noir.Domain.Shared;

public class FileExtension
{
    public FileExtension(string type)
    {
        Type = type;
    }

    public string Type { get; }

    public override string ToString()
    {
        return Type;
    }

    public static FileExtension? Parse(string text)
    {
        var type = Path.GetExtension(text);

        if (type is null)
        {
            return null;
        }

        return new FileExtension(type);
    }
}

