namespace Day08;

public static class AntinodeLocator
{
    public static IEnumerable<(int X, int Y)> Locate(char[][] map, bool repeatFrequency)
    {
        var antennaLocations = FindAntennas(map).ToList();
        var matchingAntennaFrequencyLocations = antennaLocations.GroupBy(antenna => antenna.frequency);

        var mapHeight = map.Length;
        var mapWidth = map[0].Length;
        
        var antinodes = CreateAntinodes(matchingAntennaFrequencyLocations, (mapWidth, mapHeight), repeatFrequency);
        var result = antinodes.Select(node => (node.X, node.Y));
        
        if (repeatFrequency)
        {
            result = result.Concat(antennaLocations.Select(ant => (ant.x, ant.y)));
        }

        return result.Distinct();
    }

    private static IEnumerable<(int X, int Y, char frequency)> CreateAntinodes(IEnumerable<IGrouping<char,(int x, int y, char frequency)>> matchingAntennaFrequencyLocations, (int Width, int Height) mapSize, bool repeatFrequency)
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
                    antinodes.AddRange(GetAntinodePositions(antenna, otherAntenna, mapSize, repeatFrequency));
                }
            }
        }

        return antinodes;
    }

    private static IEnumerable<(int X, int Y, char frequency)> GetAntinodePositions(
        (int x, int y, char frequency) antenna, 
        (int x, int y, char frequency) otherAntenna, 
        (int Width, int Height) mapSize, 
        bool repeatFrequency)
    {
        foreach (var valueTuple in GetAntinodePositionsAntenna(antenna, otherAntenna, mapSize, repeatFrequency)) yield return valueTuple;
        foreach (var valueTuple in GetAntinodePositionsAntenna(otherAntenna, antenna, mapSize, repeatFrequency)) yield return valueTuple;
    }

    private static IEnumerable<(int X, int Y, char frequency)> GetAntinodePositionsAntenna(
        (int x, int y, char frequency) antenna,
        (int x, int y, char frequency) otherAntenna, 
        (int Width, int Height) mapSize,
        bool repeatFrequency)
    {
        var diffX = otherAntenna.x - antenna.x;
        var diffY = otherAntenna.y - antenna.y;
        
        var newX = otherAntenna.x + diffX;
        var newY = otherAntenna.y + diffY;

        var count = 0;
        
        while (newX >= 0 && newX <= mapSize.Width - 1 && newY >= 0 && newY <= mapSize.Height - 1)
        {
            count++;
            
            yield return (newX, newY, antenna.frequency);
            newX += diffX;
            newY += diffY;

            if (count == 1 && !repeatFrequency)
            {
                break;
            }
        }
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