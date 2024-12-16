namespace Day14;

public static class SafetyFactorCalculator
{
    public static int Calculate(IEnumerable<Position> positions, MapSize mapSize)
    {
        var robotsInQuadrant = positions.Where(pos => pos.X != mapSize.Width / 2 && pos.Y != mapSize.Height / 2); 
        var robotsGroupedByQuadrant = robotsInQuadrant.GroupBy(position => GetQuadrant(position, mapSize));

        var result = 1;
        
        foreach (var group in robotsGroupedByQuadrant)
        {
            result *= group.Count();
        }

        return result;
    }

    private static int GetQuadrant(Position arg, MapSize mapSize)
    {
        if (arg.X < mapSize.Width / 2 && arg.Y < mapSize.Height / 2)
            return 1;
        if (arg.X < mapSize.Width && arg.Y < mapSize.Height / 2)
            return 2;
        if (arg.X < mapSize.Width / 2 && arg.Y < mapSize.Height)
            return 3;
        if (arg.X < mapSize.Width && arg.Y < mapSize.Height)
            return 4;
        
        throw new InvalidDataException($"Unable to determine quadrant for position {arg} in map size {mapSize}");
    }
}