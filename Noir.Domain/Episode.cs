namespace Noir.Domain;

public class Episode
{
    public Episode(EpisodeTitle title, EpisodeIndex index, Quality? quality = null, FileExtension? extension = null)
    {
        Title = title;
        Index = index;
        Quality = quality;
        Extension = extension;
    }

    public EpisodeTitle Title { get; }
    public EpisodeIndex Index { get; }
    public Quality? Quality { get; }
    public FileExtension? Extension { get; }

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
        var quality = Quality.Parse(fileName);
        var title = EpisodeTitle.Parse(fileName, index, quality);
        var extension = FileExtension.Parse(fileName);

        return new Episode(title, index, quality, extension);
    }
}