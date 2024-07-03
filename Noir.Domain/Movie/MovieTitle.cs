namespace Noir.Domain.Movie;

public class MovieTitle : Title
{
    public MovieTitle(string name) : base(name)
    {
    }

    public static MovieTitle Parse(string fileName, Year? year, Quality? quality)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

        if (year is not null)
        {
            var yearIndex = fileNameWithoutExtension.LastIndexOf(year.Numbers);
            var name = fileName[..yearIndex];
            return new MovieTitle(name);
        }

        return new MovieTitle(fileNameWithoutExtension);
    }
}
