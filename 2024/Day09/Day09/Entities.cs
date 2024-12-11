namespace Day09;

public class Diskmap
{
    public List<Sector> Sectors { get; set; } = new();
}

public record Sector(SectorType SectorType, int? FileId);

public record Space(SectorType SectorType, int? FileId, int SectorStartIndex, int SectorCount);

public enum SectorType
{
    Empty,
    File
}