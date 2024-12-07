namespace Day06;

public static class RouteCalculator
{
    public static int CountStepsFromStartToExit(char[][] map)
    {
        var (xStart, yStart, directionStart) = FindStart(map);

        var offMap = false;
        var x = xStart;
        var y = yStart;
        var direction = directionStart;
        
        do
        {
            (x, y, direction, offMap) = WalkUntilBlock(x, y, direction, map);
        } while (!offMap);

        return CountX(map);
    }

    private static int CountX(char[][] map)
    {
        var count = 0;
        
        foreach (var t in map)
        {
            count += t.Count(t1 => t1 == 'X');
        }

        return count;
    }

    private static (int x, int y, Direction newDirection, bool offMap) WalkUntilBlock(int xStart, int yStart, Direction direction, char[][] map)
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

        for (var y = yStart; y < map.Length && y >= 0; y += yDirection)
        {
            for (var x = xStart; x < map[0].Length && x >= 0; x += xDirection)
            {
                if (map[y][x] == '.' || map[y][x] == '^' || map[y][x] == 'V' || map[y][x] == '<' || map[y][x] == '>')
                {
                    map[y][x] = 'X';
                }
                
                if (y + yDirection < 0 || y + yDirection >= map.Length || 
                    x + xDirection < 0 || x + xDirection >= map[0].Length)
                {
                    return (x, y, direction, true);
                }
                
                if (map[y + yDirection][x + xDirection] == '#')
                {
                    return (x, y, GetNewDirection(direction), false);
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
        
        throw new InvalidDataException("Unable to reach end of map of block");
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