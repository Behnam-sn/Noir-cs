namespace Noir.Domain.Tests;

public class MovieProcessorTests
{
    private readonly MovieProcessor _sut = new();

    [Theory]
    [InlineData("", null)]
    [InlineData("Babylon.2022.720p.10bit.WEBRip.6CH.x265.HEVC-PSA.mkv", "Babylon.mkv")]
    [InlineData("Jimmy.Carr.Natural.Born.Killer.2024.720p.10bit.WEBRip.2CH.x265.HEVC-PSA.mkv", "Jimmy Carr Natural Born Killer.mkv")]
    public void ProcessTest(string fileName, string? expected)
    {
        // Given
        // When
        var actual = _sut.Process(fileName: fileName);
        // Then
        Assert.Equal(expected, actual);
    }
}