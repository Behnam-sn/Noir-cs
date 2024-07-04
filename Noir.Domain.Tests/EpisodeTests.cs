using Noir.Domain.Episodes;

namespace Noir.Domain.Tests;

public class EpisodeTests
{
    //[InlineData("Regular.Show.S08E30E31.A.Regular.Epic.Final.Battle.Part.2.720p.STAN.WEB-DL.x264", "Regular Show S08E30E31")]
    [Theory]
    [InlineData("", null)]
    [InlineData("Regular.Show.S01E01.720p.BluRay.x265.mkv", "Regular Show S01E01.mkv")]
    [InlineData("Regular.Show.S08E27.A.Regular.Epic.Final.Battle.Part.1.720p.STAN.WEB-DL.x264.mkv", "Regular Show S08E27.mkv")]
    [InlineData("Invincible.2021.S02E01.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Invincible S02E01.mkv")]
    [InlineData("Kaiju.No.8.S01E01.DUAL-AUDIO.JAP-ENG.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Kaiju No. 8 S01E01.mkv")]
    [InlineData("Solo.Leveling.A.K.A.Ore.dake.Level.Up.na.Ken.S01E01.JAPANESE.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Solo Leveling A.K.A. Ore dake Level Up na Ken S01E01.mkv")]
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
