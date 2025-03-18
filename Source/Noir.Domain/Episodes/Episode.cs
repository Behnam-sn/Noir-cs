using Noir.Domain.Shared;

namespace Noir.Domain.Episodes;

public sealed class Episode
{
    public EpisodeTitle Title { get; }
    public EpisodeIndex Index { get; }
    public Year? Year { get; }
    public Quality? Quality { get; }
    public FileExtension? Extension { get; }

    public Episode(
        EpisodeTitle title,
        EpisodeIndex index,
        Year? year = null,
        Quality? quality = null,
        FileExtension? extension = null
    )
    {
        Title = title;
        Index = index;
        Year = year;
        Quality = quality;
        Extension = extension;
    }

    public override string ToString()
    {
        return $"{Title} {Index}{Extension}";
    }

    public static Episode? Parse(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }

        var index = EpisodeIndex.Parse(fileName);

        if (index is null)
        {
            return null;
        }

        var year = Year.Parse(fileName);
        var quality = Quality.Parse(fileName);
        var title = EpisodeTitle.Parse(fileName, index, year, quality);
        var extension = FileExtension.Parse(fileName);

        return new Episode(title, index, year, quality, extension);
    }
}
