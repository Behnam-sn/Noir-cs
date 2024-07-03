using Noir.Domain.Movies;

namespace Noir.Domain.Tests;

public class MovieTests
{
    [Theory]
    [InlineData("", null)]
    [InlineData("Babylon.2022.720p.10bit.WEBRip.6CH.x265.HEVC-PSA.mkv", "Babylon.mkv")]
    [InlineData("Jimmy.Carr.Natural.Born.Killer.2024.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Jimmy Carr Natural Born Killer.mkv")]
    public void ParseTest(string fileName, string? expected)
    {
        // Given
        // When
        var movie = Movie.Parse(fileName: fileName);
        var actual = movie?.ToString();
        // Then
        Assert.Equal(expected, actual);
    }
}
