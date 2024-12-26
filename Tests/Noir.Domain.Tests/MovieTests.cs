using Noir.Domain.Movies;

namespace Noir.Domain.Tests;

public class MovieTests
{
    [Theory]
    [InlineData("", null)]
    [InlineData("Babylon.2022.720p.10bit.WEBRip.6CH.x265.HEVC-PSA.mkv", "Babylon.mkv")]
    [InlineData("Jimmy.Carr.Natural.Born.Killer.2024.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Jimmy Carr Natural Born Killer.mkv")]
    [InlineData("Invincible.Presenting.Atom.Eve.Special.Episode.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Invincible Presenting Atom Eve Special Episode.mkv")]
    [InlineData("Fantastic.Mr.Fox.2009.720p.10bit.6CH.x265.PSA.mkv", "Fantastic Mr. Fox.mkv")]
    [InlineData("Race to Witch Mountain (2009) BluRay 720p.mkv", "Race to Witch Mountain.mkv")]
    [InlineData("My.Neighbor.Totoro.A.K.A.Tonari.no.Totoro.1988.DUAL-AUDIO.JAP-ENG.720p.10bit.BluRay.2CH.x265.HEVC-PSA.mkv", "My Neighbor Totoro A.K.A. Tonari no Totoro.mkv")]
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
