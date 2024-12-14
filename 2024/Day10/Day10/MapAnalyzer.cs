namespace Day10;

public static class MapAnalyzer
{
    public static int CountTrailEnds(int[][] map)
    {
        var trailsEnds = new List<(int x, int y)>();
        
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                // head of trail
                if (map[y][x] == 0)
                {
                    trailsEnds.AddRange(FindTrailEnds(map, x, y, -1).Distinct());
                }
            }
        }
        
        return trailsEnds.Count();
    }

    private static List<(int x, int y)> FindTrailEnds(int[][] map, int x, int y, int previousValue)
    {
        if (y < 0 || y >= map.Length ||
            x < 0 || x >= map[0].Length)
        {
            return [];
        }

        var currentValue = map[y][x];
        if (currentValue != previousValue + 1)
        {
            return [];
        }
        
        if (currentValue == 9)
        {
            return [(x, y)];
        }

        var trailCombos = new List<(int x, int y)>();
        
        trailCombos.AddRange(FindTrailEnds(map, x + 1, y, currentValue)); // right
        trailCombos.AddRange(FindTrailEnds(map, x - 1, y, currentValue)); // left
        trailCombos.AddRange(FindTrailEnds(map, x, y - 1, currentValue)); // up
        trailCombos.AddRange(FindTrailEnds(map, x, y + 1, currentValue)); // down
        
        return trailCombos;
    }
}