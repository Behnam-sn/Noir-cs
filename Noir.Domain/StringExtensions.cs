namespace Noir.Domain;

internal static class StringExtensions
{
    internal static string Clean(this string text)
    {
        var possibleSeparators = new List<Separator>()
        {
            new(text: text, character :' '),
            new(text: text, character: '.'),
            new(text: text, character: '-'),
        };
        var separator = possibleSeparators.MaxBy(t => t.Count);
        var cleanName = separator.Character == ' ' ? text : text.Replace(separator.Character, ' ');
        return cleanName.Trim();
    }
}