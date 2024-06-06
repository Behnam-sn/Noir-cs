namespace Noir.Domain;

public class Episode
{
    public Episode(string title, int season, int episode, string? quality = null, string? extension = null)
    {
        Title = title;
        Season = season;
        EpisodeNumber = episode;
        Quality = quality;
        Extension = extension;
    }

    public string Title { get; }
    public int Season { get; }
    public int EpisodeNumber { get; }
    public string? Quality { get; }
    public string? Extension { get; }

    public override string ToString()
    {
        return $"{Title} S{Season}E{EpisodeNumber}{Extension}";
    }

    public static Episode? Parse(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }

        var season = ExtractSeason(fileName);
        var episode = ExtractEpisode(fileName);
        var quality = ExtractQuality(fileName);
        var title = ExtractTitle(fileName, season, episode, quality);
        var cleanTitle = ClearTitle(title);
        var extension = Path.GetExtension(fileName);

        return new Episode(cleanTitle, season, episode, quality, extension);
    }

    private static int ExtractSeason(string fileName)
    {
        throw new NotImplementedException();
    }

    private static int ExtractEpisode(string fileName)
    {
        throw new NotImplementedException();
    }

    private static string? ExtractQuality(string fileName)
    {
        throw new NotImplementedException();
    }

    private static string ExtractTitle(string fileName, int season, int episode, string? quality)
    {
        throw new NotImplementedException();
    }

    private static string ClearTitle(object title)
    {
        throw new NotImplementedException();
    }
}