namespace Day09;

public class Diskmap
{
    public List<Sector> Sectors { get; init; } = new();
}

public record Sector(SectorType SectorType, int? FileId);

public enum SectorType
{
    Empty,
    File
}