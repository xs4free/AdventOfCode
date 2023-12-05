namespace AlmanacReader;

public record Seeds(IEnumerable<long> Numbers, Map? Target)
{
    public Map? Target { get; set; } = Target;
}

public record Map(string Source, string Destination, Map? Target, List<Translation> Translations)
{
    public Map? Target { get; set; } = Target;
}

public record Translation(long SourceStart, long SourceEnd, long DestinationStart, long DestinationEnd);
