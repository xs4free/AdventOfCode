namespace AlmanacReader;

internal record Seeds(List<long> Numbers, Map? Target)
{
    public Map? Target { get; set; } = Target;
}

internal record Map(string Source, string Destination, Map? Target, List<Translation> Translations)
{
    public Map? Target { get; set; } = Target;
}

internal record NumberRange(long Begin, long End);

internal record Translation(NumberRange Source, NumberRange Destination);
