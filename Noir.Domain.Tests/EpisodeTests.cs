using Noir.Domain.Episodes;

namespace Noir.Domain.Tests;

public class EpisodeTests
{
    //[InlineData("Regular.Show.S08E30E31.A.Regular.Epic.Final.Battle.Part.2.720p.STAN.WEB-DL.x264", "Regular Show S08E30E31")]
    [Theory]
    [InlineData("", null)]
    [InlineData("Regular.Show.S01E01.720p.BluRay.x265.mkv", "Regular Show S01E01.mkv")]
    [InlineData("Regular.Show.S08E27.A.Regular.Epic.Final.Battle.Part.1.720p.STAN.WEB-DL.x264.mkv", "Regular Show S08E27.mkv")]
    public void ParseTest(string fileName, string? expected)
    {
        // Given
        // When
        var series = Episode.Parse(fileName: fileName);
        var actual = series?.ToString();
        // Then
        Assert.Equal(expected, actual);
    }
}
