using Noir.Domain.Shared;

namespace Noir.Domain.Movies;

public class MovieTitle : Title
{
    public MovieTitle(string name) : base(name)
    {
    }

    public static MovieTitle Parse(string fileName, Year? year, Quality? quality)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

        var indexes = new List<int>();

        if (year != null)
        {
            indexes.Add(fileNameWithoutExtension.IndexOf(year.Numbers, StringComparison.CurrentCultureIgnoreCase));
        }

        if (quality != null)
        {
            indexes.Add(fileNameWithoutExtension.IndexOf(quality.Type, StringComparison.CurrentCultureIgnoreCase));
        }

        if (indexes.Count > 0)
        {
            var name = fileNameWithoutExtension[..indexes.Min()];
            return new MovieTitle(name);
        }

        return new MovieTitle(fileNameWithoutExtension);
    }
}
