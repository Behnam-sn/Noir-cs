namespace Noir.Presentation.Contracts;

public sealed record Command(IEnumerable<string> Titles, Action Action);
