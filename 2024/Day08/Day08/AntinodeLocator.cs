namespace Day08;

public static class AntinodeLocator
{
    public static IEnumerable<(int X, int Y)> Locate(char[][] map)
    {
        var antennaLocations = FindAntennas(map);
        var matchingAntennaFrequencyLocations = antennaLocations.GroupBy(antenna => antenna.frequency);

        var antinodes = CreateAntinodes(matchingAntennaFrequencyLocations);
        
        var mapSizeY = map.Length;
        var mapSizeX = map[0].Length;
        
        return antinodes.Select(node => (node.X, node.Y)).Where(node => node.X >= 0 && node.X <= mapSizeX - 1 && node.Y >= 0 && node.Y <= mapSizeY - 1).Distinct();
    }

    private static IEnumerable<(int X, int Y, char frequency)> CreateAntinodes(IEnumerable<IGrouping<char,(int x, int y, char frequency)>> matchingAntennaFrequencyLocations)
    {
        var antinodes = new List<(int X, int Y, char frequency)>();
        
        foreach (var frequency in matchingAntennaFrequencyLocations)
        {
            var antennas = frequency.ToList();

            foreach (var antenna in antennas)
            {
                var otherAntennas = antennas.Where(ant => ant != antenna).ToList();
                foreach (var otherAntenna in otherAntennas)
                {
                    antinodes.AddRange(GetAntinodePositions(antenna, otherAntenna));
                }
            }
        }

        return antinodes;
    }

    private static IEnumerable<(int X, int Y, char frequency)> GetAntinodePositions((int x, int y, char frequency) antenna, (int x, int y, char frequency) otherAntenna)
    {
        yield return (otherAntenna.x + (otherAntenna.x - antenna.x), otherAntenna.y + (otherAntenna.y - antenna.y), antenna.frequency);
        yield return (antenna.x + (antenna.x - otherAntenna.x), antenna.y + (antenna.y - otherAntenna.y), antenna.frequency);
    }

    private static IEnumerable<(int x, int y, char frequency)> FindAntennas(char[][] map)
    {
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (IsAntenna(map[y][x]))
                {
                    yield return (x, y, map[y][x]);
                }
            }
        }
    }

    private static bool IsAntenna(char frequency)
    {
        return char.IsDigit(frequency) || char.IsLetter(frequency);
    }
}