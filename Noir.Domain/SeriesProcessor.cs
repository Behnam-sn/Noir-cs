using Noir.Domain.Contracts;

namespace Noir.Domain;

public class SeriesProcessor : IProcessor
{
    public string? Process(string fileName)
    {
        var series = Series.Parse(fileName: fileName);
        return series?.ToString();
    }
}