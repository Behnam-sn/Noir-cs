namespace Noir.Domain;

public abstract class Title
{
    public string Name { get; }

    public Title(string name)
    {
        Name = Clear(name);
    }

    public override string ToString()
    {
        return Name;
    }

    private string Clear(string name)
    {
        var possibleSeparators = new Separator[]
        {
            new(text: name, character: ' '),
            new(text: name, character: '.'),
            new(text: name, character: '-'),
            new(text: name, character: '_'),
        };
        var separator = possibleSeparators.MaxBy(t => t.Count);

        var cleanName = separator.Character == ' ' ? name : name.Replace(separator.Character, ' ');
        return cleanName.Trim();
    }
}