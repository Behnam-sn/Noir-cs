using System.Text.RegularExpressions;

namespace Noir.Domain;

public class EpisodeIndex
{
    public EpisodeIndex(string number)
    {
        Number = number;
    }

    public string Number { get; }

    public override string ToString()
    {
        return $"E{Number}";
    }

    public static EpisodeIndex? Parse(string text)
    {
        var textToLower = text.ToLower();
        var episodeRegex = new Regex(@"s\d\de\d\d");
        var matched = episodeRegex.Matches(textToLower).Select(m => m.Value).ToList();

        var selected = matched.LastOrDefault();
        var episode = selected?.Substring(4, 2);

        if (episode is null)
        {
            return null;
        }

        return new EpisodeIndex(episode);
    }
}