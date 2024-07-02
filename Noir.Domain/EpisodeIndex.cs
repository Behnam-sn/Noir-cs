using System.Text.RegularExpressions;

namespace Noir.Domain;

public class EpisodeIndex
{
    public EpisodeIndex(string season, string episode, string currentFormat)
    {
        Season = season;
        Episode = episode;
        CurrentFormat = currentFormat;
    }

    public string Season { get; }
    public string Episode { get; }
    public string CurrentFormat { get; }

    public override string ToString()
    {
        return $"S{Season}E{Episode}";
    }

    public static EpisodeIndex? Parse(string text)
    {
        var textToLower = text.ToLower();
        // S00E00
        var episodeRegex = new Regex(@"s\d\de\d\d");
        var matched = episodeRegex.Matches(textToLower).Select(m => m.Value).ToList();

        var selected = matched.LastOrDefault();

        if (selected == null)
        {
            return null;
        }

        var season = selected.Substring(1, 2);
        var episode = selected.Substring(4, 2);

        return new EpisodeIndex(season, episode, selected);
    }
}
