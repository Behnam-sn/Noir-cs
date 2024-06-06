namespace Noir.Domain;

public class Movie
{
    public Movie(MovieTitle title, Year? year = null, Quality? quality = null, FileExtension? extension = null)
    {
        Title = title;
        Year = year;
        Quality = quality;
        Extension = extension;
    }

    public MovieTitle Title { get; }
    public Year? Year { get; }
    public Quality? Quality { get; }
    public FileExtension? Extension { get; }

    public override string ToString()
    {
        return $"{Title}{Extension}";
    }

    public static Movie? Parse(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }

        var year = Year.Parse(fileName);
        var quality = Quality.Parse(fileName);
        var title = MovieTitle.Parse(fileName, year, quality);
        var extension = FileExtension.Parse(fileName);

        return new Movie(title, year, quality, extension);
    }
}