namespace Noir.Domain.Tests;

public class MovieProcessorUnitTests
{
    private readonly MovieProcessor sut = new();

    [Theory]
    [InlineData("Babylon.2022.720p.10bit.WEBRip.6CH.x265.HEVC-PSA.mkv", "Babylon.mkv")]
    [InlineData("Jimmy.Carr.Natural.Born.Killer.2024.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Jimmy Carr Natural Born Killer.mkv")]
    public void ProcessTest(string fileName, string expected)
    {
        // Given
        // When
        var actual = sut.Process(fileName: fileName);
        // Then
        Assert.Equal(expected, actual);
    }
}