namespace FloorWillBeLava;

public static class EnergyCalculator
{
    public static int EnergizedTiles(IEnumerable<string> lines)
    {
        var map = lines.Select(line => line.ToCharArray()).ToArray();

        return WalkEnergyPath(map, 0, 0, Direction.Right);
    }

    public static int MaxEnergizedTiles(IEnumerable<string> lines)
    {
        var map = lines.Select(line => line.ToCharArray()).ToArray();

        var tilesCount = new List<int>();

        for (var x = 0; x < map[0].Length; x++)
        {
            tilesCount.Add(WalkEnergyPath(map, x, 0, Direction.Down));
            tilesCount.Add(WalkEnergyPath(map, x, map.Length - 1, Direction.Up));
        }
        for (var y = 0; y < map.Length; y++)
        {
            tilesCount.Add(WalkEnergyPath(map, 0, y, Direction.Right));
            tilesCount.Add(WalkEnergyPath(map, map[0].Length - 1, y, Direction.Left));
        }
        
        return tilesCount.Max();
    }

    private static int WalkEnergyPath(char[][] map, int x, int y, Direction direction)
    {
        var loopProtection = new HashSet<(int x, int y, Direction direction)>();
        WalkEnergyPath(map, x, y, direction, loopProtection);
        
        return loopProtection.DistinctBy<(int, int, Direction),(int, int)>(tuple => (tuple.Item1, tuple.Item2)).Count();
    }

    private static void WalkEnergyPath(
        char[][] map, 
        int x, int y, 
        Direction direction, 
        ISet<(int x, int y, Direction direction)> loopProtection)
    {
        if (x >= map[0].Length || x < 0 || 
            y >= map.Length || y < 0)
        {
            return;
        }
        if (!loopProtection.Add((x, y, direction)))
        {
            return;
        }

        switch (map[y][x])
        {
            case '|' when direction is  Direction.Left or Direction.Right:
                WalkEnergyPath(map, x, y - 1, Direction.Up, loopProtection);
                WalkEnergyPath(map, x, y + 1, Direction.Down, loopProtection);
                break;
            case '-' when direction is Direction.Up or Direction.Down:
                WalkEnergyPath(map, x - 1, y, Direction.Left, loopProtection);
                WalkEnergyPath(map, x + 1, y, Direction.Right, loopProtection);
                break;
            case '\\' when direction == Direction.Right:
                WalkEnergyPath(map, x, y + 1, Direction.Down, loopProtection);
                break;
            case '\\' when direction == Direction.Left:
                WalkEnergyPath(map, x, y - 1, Direction.Up, loopProtection);
                break;
            case '\\' when direction == Direction.Up:
                WalkEnergyPath(map, x - 1, y, Direction.Left, loopProtection);
                break;
            case '\\' when direction == Direction.Down:
                WalkEnergyPath(map, x + 1, y, Direction.Right, loopProtection);
                break;
            case '/' when direction == Direction.Right:
                WalkEnergyPath(map, x, y - 1, Direction.Up, loopProtection);
                break;
            case '/' when direction == Direction.Left:
                WalkEnergyPath(map, x, y + 1, Direction.Down, loopProtection);
                break;
            case '/' when direction == Direction.Up:
                WalkEnergyPath(map, x + 1, y, Direction.Right, loopProtection);
                break;
            case '/' when direction == Direction.Down:
                WalkEnergyPath(map, x - 1, y, Direction.Left, loopProtection);
                break;
            default:
            {
                switch (direction)
                {
                    case Direction.Up:
                        WalkEnergyPath(map, x, y - 1, direction, loopProtection);
                        break;
                    case Direction.Down:
                        WalkEnergyPath(map, x, y + 1, direction, loopProtection);
                        break;
                    case Direction.Left:
                        WalkEnergyPath(map, x - 1, y, direction, loopProtection);
                        break;
                    case Direction.Right:
                        WalkEnergyPath(map, x + 1, y, direction, loopProtection);
                        break;
                }

                break;
            }
        }
    }
}