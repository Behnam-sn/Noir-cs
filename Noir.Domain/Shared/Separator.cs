namespace Noir.Domain.Shared;

internal class Separator
{
    public Separator(string text, char character)
    {
        Character = character;
        Count = text.Count(c => c == Character);
    }

    public char Character { get; }
    public int Count { get; }
}
