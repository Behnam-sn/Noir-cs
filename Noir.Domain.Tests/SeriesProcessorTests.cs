namespace Noir.Domain.Tests;

public class SeriesProcessorTests
{
    private readonly SeriesProcessor _sut = new();

    //[InlineData("Regular.Show.S08E30E31.A.Regular.Epic.Final.Battle.Part.2.720p.STAN.WEB-DL.x264", "Regular Show S08E30E31")]
    [Theory]
    [InlineData("", null)]
    [InlineData("Regular.Show.S01E01.720p.BluRay.x265", "Regular Show S01E01")]
    [InlineData("Regular.Show.S08E27.A.Regular.Epic.Final.Battle.Part.1.720p.STAN.WEB-DL.x264", "Regular Show S08E27")]
    public void ProcessTest(string fileName, string? expected)
    {
        // Given
        // When
        var actual = _sut.Process(fileName: fileName);
        // Then
        Assert.Equal(expected, actual);
    }
}