using System.Text.RegularExpressions;

namespace Noir.Domain;

public class Movie
{
    public Movie(string title, string? year = null, string? quality = null, string? extension = null)
    {
        Title = title;
        Year = year;
        Quality = quality;
        Extension = extension;
    }

    public string Title { get; }
    public string? Year { get; }
    public string? Quality { get; }
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

        var year = ExtractYear(fileName);
        var quality = ExtractQuality(fileName);
        var title = ExtractTitle(fileName, year, quality);
        var cleanTitle = ClearTitle(title);
        var extension = Path.GetExtension(fileName);

        return new Movie(cleanTitle, year, quality, extension);
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

    private static string ExtractTitle(string fileName, string? year, string? quality)
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