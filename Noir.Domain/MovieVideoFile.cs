using System.Text.RegularExpressions;

namespace Noir.Domain;

internal class MovieVideoFile : IMovie, IVideoFile
{
    public MovieVideoFile(string name, string format, string? year = null, string? quality = null)
    {
        Name = name;
        Year = year;
        Quality = quality;
        Format = format;
    }

    public string Name { get; }
    public string? Year { get; }
    public string? Quality { get; }
    public string Format { get; }

    public override string ToString()
    {
        return Name;
    }

    internal static MovieVideoFile Parse(string fileName)
    {
        // year
        var yearRegex = new Regex(@"\d\d\d\d");
        var matchedYears = yearRegex.Matches(fileName).Select(m => m.Value).ToList();
        matchedYears.Remove("1080");
        var year = matchedYears.LastOrDefault();
        // find quality
        if (year is not null)
        {
            var yearIndex = fileName.LastIndexOf(year);
            var name = fileName[..yearIndex];
            return new MovieVideoFile(name: name.Clean(), format: "", year: year);
        }
        return new MovieVideoFile(name: fileName.Clean(), format: "");
    }
}