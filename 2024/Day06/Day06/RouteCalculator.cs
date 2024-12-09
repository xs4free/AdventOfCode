namespace Day06;

public static class RouteCalculator
{
    public static int CountStepsFromStartToExit(char[][] map)
    {
        var (x, y, direction) = FindStart(map);
        var (_, positionsUntilEndOfMap) = UniquePositionsUntilEndOfMap(map, x, y, direction);

        return positionsUntilEndOfMap.Select(p => (p.x, p.y)).Distinct().Count();
    }

    public static IEnumerable<(int x, int y)> GetPositionsForEndlessLoop(char[][] map)
    {
        var (xStart, yStart, directionStart) = FindStart(map);

        var (_, positionsUntilEndOfMap) = UniquePositionsUntilEndOfMap(map, xStart, yStart, directionStart);
        var endlessLoopPositions = new List<(int x, int y)>();

        var possibleBlockPositions = positionsUntilEndOfMap.Select(p => (p.x, p.y)).Distinct().ToList();
        
        foreach (var position in possibleBlockPositions)
        {
            // temporarily add block on map
            map[position.y][position.x] = '#';
            
            var (endlessLoopDetected, _) = UniquePositionsUntilEndOfMap(map, xStart, yStart, directionStart);
            if (endlessLoopDetected)
            {
                endlessLoopPositions.Add((position.x, position.y));
            }
            
            // reset map to original status
            map[position.y][position.x] = '.';
        }

        return endlessLoopPositions;
    }
    
    private static (bool loopDetected, IEnumerable<(int x, int y, Direction direction)>) UniquePositionsUntilEndOfMap(char[][] map, int xStart, int yStart, Direction directionStart)
    {
        var x = xStart;
        var y = yStart;
        var direction = directionStart;
        var visited = new HashSet<(int x, int y, Direction direction)>();
        bool loopDetected = false;
        
        do
        {
            var (blockFound, positionsUntilBlock) = GetPositionsUntilBlock(x, y, direction, map);

            if (positionsUntilBlock.Any(position => !visited.Add((position.x, position.y, direction))))
            {
                loopDetected = true;
            }

            if (!blockFound)
            {
                break;
            }
            
            direction = GetNewDirection(direction);
            if (positionsUntilBlock.Any())
            {
                // it's valid to change direction but not position
                // when for instance you are heading down and there is a block below and to the left
                (x, y) = positionsUntilBlock.Last();
            }
        } while (!loopDetected);
        
        return (loopDetected, visited);
    }

    private static (bool blockFound, List<(int x, int y)>) GetPositionsUntilBlock(int xStart, int yStart, Direction direction, char[][] map)
    {
        var xDirection = direction switch
        {
            Direction.Left => -1,
            Direction.Right => 1,
            _ => 0
        };
        var yDirection = direction switch
        {
            Direction.Up => -1,
            Direction.Down => 1,
            _ => 0
        };

        var blockFound = false;
        List<(int x, int y)> positionsUntilBlock = [];
        
        for (var y = yStart; y < map.Length && y >= 0 && !blockFound; y += yDirection)
        {
            for (var x = xStart; x < map[0].Length && x >= 0 && !blockFound; x += xDirection)
            {
                // don't return the starting position
                if (y != yStart || x != xStart)
                {
                    positionsUntilBlock.Add((x, y));
                }
                
                if (y + yDirection < map.Length && y + yDirection >= 0 &&
                    x + xDirection < map[0].Length && x + xDirection >= 0 &&
                    map[y + yDirection][x + xDirection] == '#')
                {
                    blockFound = true;
                }

                if (xDirection == 0)
                {
                    break;
                }
            }

            if (yDirection == 0)
            {
                break;
            }
        }
        
        return (blockFound, positionsUntilBlock);
    }

    private static Direction GetNewDirection(Direction currentDirection)
    {
        return currentDirection switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => throw new ArgumentOutOfRangeException(nameof(currentDirection))
        };
    }

    private static (int x, int y, Direction direction) FindStart(char[][] map)
    {
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                switch (map[y][x])
                {
                    case '^': return (x, y, Direction.Up);
                    case 'V': return (x, y, Direction.Down);
                    case '<': return (x, y, Direction.Left);
                    case '>': return (x, y, Direction.Right);
                }
            }
        }
        
        throw new InvalidDataException("Map has no starting point");
    }
}