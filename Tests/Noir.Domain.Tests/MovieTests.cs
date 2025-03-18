using Noir.Domain.Movies;

namespace Noir.Domain.Tests;

public sealed class MovieTests
{
    [Theory]
    [InlineData("", null, null)]
    [InlineData("Babylon.2022.720p.10bit.WEBRip.6CH.x265.HEVC-PSA.mkv", "Babylon.mkv", "Babylon (2022).mkv")]
    // [InlineData("Fantastic.Mr.Fox.2009.720p.10bit.6CH.x265.PSA.mkv", "Fantastic Mr. Fox.mkv")]
    // [InlineData("Race to Witch Mountain (2009) BluRay 720p.mkv", "Race to Witch Mountain.mkv")]
    // [InlineData("My.Neighbor.Totoro.A.K.A.Tonari.no.Totoro.1988.DUAL-AUDIO.JAP-ENG.720p.10bit.BluRay.2CH.x265.HEVC-PSA.mkv", "My Neighbor Totoro A.K.A. Tonari no Totoro.mkv")]
    public void ParseTest(string fileName, string? expected, string? expectedWithYear)
    {
        // Given
        // When
        var movie = Movie.Parse(fileName);
        var actual = movie?.GenerateFileName();
        var actualWithYear = movie?.GenerateFileName(withYear: true);
        // Then
        Assert.Equal(expected, actual);
        Assert.Equal(expectedWithYear, actualWithYear);
    }
}
