using System.Text.RegularExpressions;

namespace Noir.Domain;

public class Season
{
    public Season(string number)
    {
        Number = number;
    }

    public string Number { get; }

    public override string ToString()
    {
        return $"S{Number}";
    }

    public static Season? Parse(string text)
    {
        var textToLower = text.ToLower();
        var seasonRegex = new Regex(@"s\d\de\d\d");
        var matched = seasonRegex.Matches(textToLower).Select(m => m.Value).ToList();

        var selected = matched.LastOrDefault();
        var season = selected?.Substring(1, 2);

        if (season is null)
        {
            return null;
        }

        return new Season(season);
    }
}