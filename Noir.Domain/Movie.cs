namespace Noir.Domain;

public class Movie
{
    public Movie(MovieTitle title, Year? year = null, Quality? quality = null, string? extension = null)
    {
        Title = title;
        Year = year;
        Quality = quality;
        Extension = extension;
    }

    public MovieTitle Title { get; }
    public Year? Year { get; }
    public Quality? Quality { get; }
    public string? Extension { get; }

    public override string ToString()
    {
        return $"{Title}{Extension}";
    }

    public static Movie? Parse(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }

        var year = Year.Parse(fileName);
        var quality = Quality.Parse(fileName);
        var title = MovieTitle.Parse(fileName, year, quality);
        var extension = Path.GetExtension(fileName);

        return new Movie(title, year, quality, extension);
    }

    private static string ClearTitle(string name)
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