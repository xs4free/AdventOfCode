namespace FloorWillBeLava;

public static class EnergyCalculator
{
    public static int EnergizedTiles(IEnumerable<string> lines)
    {
        var map = lines.Select(line => line.ToCharArray()).ToArray();

        var energizedPositions = new HashSet<(int x, int y)>();
        var energizedPositionsPlusDirection = new HashSet<(int x, int y, Direction direction)>();
        
        WalkEnergyPath(map, -1, 0, Direction.Right, energizedPositions, energizedPositionsPlusDirection);

        return energizedPositions.Count;
    }

    private static int WalkEnergyPath(
        char[][] map, 
        int x, int y, 
        Direction direction, 
        ISet<(int x, int y)> energizedPositions, 
        ISet<(int x, int y, Direction direction)> energizedPositionsPlusDirection)
    {
        var nextX = direction == Direction.Left ? x - 1 : direction == Direction.Right ? x + 1 : x;
        var nextY = direction == Direction.Up ? y - 1 : direction == Direction.Down ? y + 1 : y;

        if (nextX >= map[0].Length || nextX < 0)
        {
            return 0;
        }

        if (nextY >= map.Length || nextY < 0)
        {
            return 0;
        }

        energizedPositions.Add((nextX, nextY));
        if (!energizedPositionsPlusDirection.Add((nextX, nextY, direction)))
        {
            // infinite loop detected (already passed this point from the same direction)
            return 0;
        }

        var steps = 1;
        steps += (chr: map[nextY][nextX], direction) switch
        {
            { chr: '|', direction: Direction.Left or Direction.Right } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Up, energizedPositions, energizedPositionsPlusDirection)
                + WalkEnergyPath(map, nextX, nextY, Direction.Down, energizedPositions, energizedPositionsPlusDirection),
            { chr: '-', direction: Direction.Up or Direction.Down } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Left, energizedPositions, energizedPositionsPlusDirection)
                + WalkEnergyPath(map, nextX, nextY, Direction.Right, energizedPositions, energizedPositionsPlusDirection),
            { chr: '\\', direction: Direction.Right } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Down, energizedPositions, energizedPositionsPlusDirection),
            { chr: '\\', direction: Direction.Left } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Up, energizedPositions, energizedPositionsPlusDirection),
            { chr: '\\', direction: Direction.Up } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Left, energizedPositions, energizedPositionsPlusDirection),
            { chr: '\\', direction: Direction.Down } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Right, energizedPositions, energizedPositionsPlusDirection),
            { chr: '/', direction: Direction.Right } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Up, energizedPositions, energizedPositionsPlusDirection),
            { chr: '/', direction: Direction.Left } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Down, energizedPositions, energizedPositionsPlusDirection),
            { chr: '/', direction: Direction.Up } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Right, energizedPositions, energizedPositionsPlusDirection),
            { chr: '/', direction: Direction.Down } =>
                WalkEnergyPath(map, nextX, nextY, Direction.Left, energizedPositions, energizedPositionsPlusDirection),
            _ => WalkEnergyPath(map, nextX, nextY, direction, energizedPositions, energizedPositionsPlusDirection)
        };
        
        return steps;
    }
}