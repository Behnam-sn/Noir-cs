namespace Noir.Domain;

public class MovieProcessor : IProcessor
{
    public string Process(string fileName)
    {
        var movie = MovieFile.Parse(fileName: fileName);
        return movie.ToString();
    }
}