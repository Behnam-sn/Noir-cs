namespace Noir.Domain;

public class Episode
{
    public Episode(EpisodeTitle title, Season season, EpisodeIndex episodeIndex, Quality? quality = null, FileExtension? extension = null)
    {
        Title = title;
        Season = season;
        EpisodeIndex = episodeIndex;
        Quality = quality;
        Extension = extension;
    }

    public EpisodeTitle Title { get; }
    public Season Season { get; }
    public EpisodeIndex EpisodeIndex { get; }
    public Quality? Quality { get; }
    public FileExtension? Extension { get; }

    public override string ToString()
    {
        return $"{Title} {Season}{EpisodeIndex}{Extension}";
    }

    public static Episode? Parse(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }

        var season = Season.Parse(fileName);
        var episode = EpisodeIndex.Parse(fileName);
        var quality = Quality.Parse(fileName);
        var title = EpisodeTitle.Parse(fileName, season, episode, quality);
        var extension = FileExtension.Parse(fileName);

        return new Episode(title, season, episode, quality, extension);
    }
}