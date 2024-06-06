namespace Noir.Domain;

public class Season
{
    public Season(int number)
    {
        Number = number;
    }

    public int Number { get; }

    public override string ToString()
    {
        return $"S{Number}";
    }

    public static Season? Parse(string text)
    {
        return null;
    }
}