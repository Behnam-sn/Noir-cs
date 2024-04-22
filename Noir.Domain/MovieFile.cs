using Noir.Domain.Contracts;
using System.Text.RegularExpressions;

namespace Noir.Domain;

internal class MovieFile : IMovie, IVideoFile
{
    public MovieFile(string name, string format, string? year = null, string? quality = null)
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
        return $"{Name}.{Format}";
    }

    internal static MovieFile Parse(string fullFileName)
    {
        var lastIndexOfDot = fullFileName.LastIndexOf('.');
        var fileName = fullFileName[..lastIndexOfDot];
        var fileFormat = fullFileName[(lastIndexOfDot + 1)..];
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
            return new MovieFile(name: name.Clean(), format: fileFormat, year: year);
        }
        return new MovieFile(name: fileName.Clean(), format: fileFormat);
    }
}