namespace Day09.Tests;

internal static class SectorFactory
{
    internal static IEnumerable<Sector> CreateSectorsFromString(string input)
    {
        return input.Select(chr => chr == '.'
            ? new Sector(SectorType.Empty, null)
            : new Sector(SectorType.File, chr - 48));
    }
    
}