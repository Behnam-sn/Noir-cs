using System.Text.RegularExpressions;

namespace Noir.Domain.Shared;

public sealed class Year
{
    public string Numbers { get; }

    public Year(string text)
    {
        Numbers = text;
    }

    public override string ToString()
    {
        return Numbers;
    }

    public static Year? Parse(string text)
    {
        var yearRegex = new Regex(@"\d\d\d\d");
        var matchedYears = yearRegex.Matches(text).Select(m => m.Value).ToList();
        matchedYears.Remove("1080");
        var year = matchedYears.LastOrDefault();

        if (year is null)
        {
            return null;
        }

        return new Year(year);
    }
}
