namespace Noir.Presentation.Abstractions;

public sealed record Command(IEnumerable<string> Titles, Action Action);
