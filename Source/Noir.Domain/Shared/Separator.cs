namespace Noir.Domain.Shared;

internal sealed class Separator
{
    public char Character { get; }
    public int Count { get; }

    public Separator(string text, char character)
    {
        Character = character;
        Count = text.Count(c => c == Character);
    }
}
