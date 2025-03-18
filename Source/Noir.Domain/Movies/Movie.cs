using System.Text;
using Noir.Domain.Shared;

namespace Noir.Domain.Movies;

public sealed class Movie
{
    public MovieTitle Title { get; }
    public Year? Year { get; }
    public Quality? Quality { get; }
    public FileExtension? Extension { get; }

    public Movie(
        MovieTitle title,
        Year? year = null,
        Quality? quality = null,
        FileExtension? extension = null
    )
    {
        Title = title;
        Year = year;
        Quality = quality;
        Extension = extension;
    }

    public string GenerateFileName(bool withYear = false)
    {
        var fileName = new StringBuilder();
        fileName.Append(Title);

        if (withYear == true && Year is not null)
        {
            fileName.Append($" ({Year})");
        }

        if (Extension is not null)
        {
            fileName.Append(Extension);
        }

        return fileName.ToString();
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
