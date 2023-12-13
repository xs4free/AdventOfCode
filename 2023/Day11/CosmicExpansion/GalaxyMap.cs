namespace CosmicExpansion;

public static class GalaxyMap
{
    public static long SumShortestPaths(IEnumerable<string> input, int expansionRate)
    {
        var map = ReadMap(input);
        var expandedMap = ExpandMap(map, expansionRate);
        
        var galaxies = GetGalaxies(expandedMap);

        var galaxyPairs = GetPairs(galaxies);
        
        return galaxyPairs.Sum(pair => pair.ShortestPath);
    }

    private static long CalculateShortestPath(Galaxy galaxy1, Galaxy galaxy2)
    {
        var x = Math.Max(galaxy1.X, galaxy2.X) - Math.Min(galaxy1.X, galaxy2.X);
        var y = Math.Max(galaxy1.Y, galaxy2.Y) - Math.Min(galaxy1.Y, galaxy2.Y);

        return x + y;
    }

    private static List<GalaxyPair> GetPairs(List<Galaxy> galaxies)
    {
        List<GalaxyPair> result = [];
        HashSet<string> pairsCreated = [];

        var galaxies1 = galaxies.ToList();
        var galaxies2 = galaxies.ToList();

        foreach (var galaxy1 in galaxies1)
        {
            foreach (var galaxy2 in galaxies2)
            {
                var pairKey = galaxy1.Number < galaxy2.Number ? $"{galaxy1.Number}-{galaxy2.Number}" : $"{galaxy2.Number}-{galaxy1.Number}";
                if (galaxy1 != galaxy2 && pairsCreated.Add(pairKey))
                {
                    result.Add(new GalaxyPair(galaxy1, galaxy2, CalculateShortestPath(galaxy1, galaxy2)));
                }
            }
        }

        return result;
    }

    private static List<Galaxy> GetGalaxies(Map map)
    {
        var galaxyNumber = 1;
        var result = new List<Galaxy>();
        
        for (var y = 0; y < map.Position.Length; y++)
        {
            var line = map.Position[y];
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '#')
                {
                    var expandedX = map.ColumnExpansions[..x].Sum();
                    var expandedY = map.RowExpansions[..y].Sum();
                    result.Add(new Galaxy(galaxyNumber++, expandedX, expandedY));
                }
            }
        }

        return result;
    }

    private static Map ExpandMap(char[][] map, long expansionRate) => 
        new Map(map, GetRowExpansions(map, expansionRate), GetColumnExpansions(map, expansionRate));

    private static List<long> GetRowExpansions(char[][] map, long expansionRate) => 
        map.Select(line => line.All(position => position != '#') ? expansionRate : 1).ToList();

    private static List<long> GetColumnExpansions(char[][] map, long expansionRate)
    {
        List<long> result = [];
        
        for (var x = 0; x < map[0].Length; x++)
        {
            result.Add(map.All(lines => lines[x] != '#') ? expansionRate : 1);
        }

        return result;
    }

    private static char[][] ReadMap(IEnumerable<string> input)
    {
        return input.Select(line => line.ToCharArray()).ToArray();
    }
}