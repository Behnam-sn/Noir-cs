using Noir.Domain.Contracts;

namespace Noir.Domain;

public class MovieProcessor : IProcessor
{
    public string Process(string fileName)
    {
        var movie = MovieFile.Parse(fullFileName: fileName);
        return movie.ToString();
    }
}