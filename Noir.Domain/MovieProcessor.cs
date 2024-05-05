using Noir.Domain.Contracts;

namespace Noir.Domain;

public class MovieProcessor : IProcessor
{
    public string? Process(string fileName)
    {
        var movie = Movie.Parse(fileName: fileName);
        return movie?.ToString();
    }
}
