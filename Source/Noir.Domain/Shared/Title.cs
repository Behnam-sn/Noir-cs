namespace Noir.Domain.Shared;

public abstract class Title
{
    public string Name { get; }

    public Title(string name)
    {
        var newName = Clear(name);
        newName = FixIrregularWords(newName);
        Name = newName;
    }

    public override string ToString()
    {
        return Name;
    }

    private static string Clear(string name)
    {
        var possibleSeparators = new Separator[]
        {
            new(text: name, character: ' '),
            new(text: name, character: '.'),
            new(text: name, character: '-'),
            new(text: name, character: '_'),
        };
        var separator = possibleSeparators.MaxBy(t => t.Count);

        var cleanName = separator!.Character == ' ' ? name : name.Replace(separator.Character, ' ');
        return cleanName.Trim();
    }

    private static string FixIrregularWords(string name)
    {
        return name
            .Replace(" A K A ", " A.K.A. ", StringComparison.CurrentCultureIgnoreCase)
            .Replace(" Mr ", " Mr. ", StringComparison.CurrentCultureIgnoreCase);
    }
}
