namespace CosmicExpansion;

public static class GalaxyMap
{
    public static int SumShortestPaths(IEnumerable<string> input)
    {
        var map = ReadMap(input);
        map = ExpandMap(map);
        
        var galaxies = GetGalaxies(map);

        var galaxyPairs = GetPairs(galaxies);

        CalculateShortestPath(galaxyPairs);
        
        return galaxyPairs.Sum(pair => pair.ShortestPath);
    }

    private static void CalculateShortestPath(IEnumerable<GalaxyPair> galaxyPairs)
    {
        foreach (var pair in galaxyPairs)
        {
            var x = Math.Max(pair.Galaxy1.X, pair.Galaxy2.X) - Math.Min(pair.Galaxy1.X, pair.Galaxy2.X);
            var y = Math.Max(pair.Galaxy1.Y, pair.Galaxy2.Y) - Math.Min(pair.Galaxy1.Y, pair.Galaxy2.Y);

            pair.ShortestPath = x + y;
        }
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
                    result.Add(new GalaxyPair(galaxy1, galaxy2, 0));
                }
            }
        }

        return result;
    }

    private static List<Galaxy> GetGalaxies(char[][] map)
    {
        var galaxyNumber = 1;
        var result = new List<Galaxy>();
        
        for (var y = 0; y < map.Length; y++)
        {
            var line = map[y];
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '#')
                {
                    result.Add(new Galaxy(galaxyNumber++, x, y));
                }
            }
        }

        return result;
    }

    private static char[][] ExpandMap(char[][] map)
    {
        var columnToExpand = GetColumnsToExpand(map).ToHashSet();

        var expandedMap = new List<List<char>>();
        
        foreach (var line in map)
        {
            var expandedLine = new List<char>();
            for (var x = 0; x < line.Length; x++)
            {
                expandedLine.Add(line[x]);
                if (columnToExpand.Contains(x))
                {
                    expandedLine.Add(line[x]);
                }
            }
            expandedMap.Add(expandedLine);
            if (expandedLine.All(position => position != '#'))
            {
                expandedMap.Add(expandedLine);
            }
        }

        return expandedMap.Select(line => line.ToArray()).ToArray();
    }

    private static IEnumerable<int> GetColumnsToExpand(char[][] map)
    {
        var result = new List<int>();
        
        for (var x = 0; x < map[0].Length; x++)
        {
            if (map.All(t => t[x] != '#'))
            {
                result.Add(x);
            }
        }

        return result;
    }

    private static char[][] ReadMap(IEnumerable<string> input)
    {
        return input.Select(line => line.ToCharArray()).ToArray();
    }
}