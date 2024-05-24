using System.Text.RegularExpressions;

namespace Noir.Domain;

internal class Movie
{
    public Movie(string name, string? year = null, string? quality = null, string? extension = null)
    {
        Name = name;
        Year = year;
        Quality = quality;
        Extension = extension;
    }

    public string Name { get; }
    public string? Year { get; }
    public string? Quality { get; }
    public string? Extension { get; }

    public override string ToString()
    {
        return $"{Name}{Extension}";
    }

    internal static Movie? Parse(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }

        var year = ExtractYear(fileName);
        var quality = ExtractQuality(fileName);
        var name = ExtractName(fileName, year, quality);
        var cleanName = ClearName(name);
        var extension = Path.GetExtension(fileName);

        return new Movie(cleanName, year, quality, extension);
    }

    private static string? ExtractYear(string fileName)
    {
        var yearRegex = new Regex(@"\d\d\d\d");
        var matchedYears = yearRegex.Matches(fileName).Select(m => m.Value).ToList();
        matchedYears.Remove("1080");
        var year = matchedYears.LastOrDefault();
        return year;
    }

    private static string? ExtractQuality(string fileName)
    {
        return null;
    }

    private static string ExtractName(string fileName, string? year, string? quality)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        if (year is not null)
        {
            var yearIndex = fileNameWithoutExtension.LastIndexOf(year);
            var name = fileName[..yearIndex];
            return name;
        }
        return fileNameWithoutExtension;
    }

    private static string ClearName(string name)
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