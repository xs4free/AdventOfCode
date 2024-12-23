namespace Day15;

public static class RobotMover
{
    public static char[][] Move(char[][] map, char[] moves)
    {
        var result  = (char[][])map.Clone();
        var robotPosition = FindRobot(result);

        foreach (var move in moves)
        {
            var newPosition = ExecuteMove(robotPosition, move, result);
            if (newPosition != null)
            {
                robotPosition = newPosition;
            }
        }
        
        return result;
    }

    private static Position FindRobot(char[][] result)
    {
        for (var y = 1; y < result.Length - 1; y++)
        {
            for (var x = 1; x < result[y].Length - 1; x++)
            {
                if (result[y][x] == '@')
                {
                    return new Position(x, y);
                }
            }
        }
        
        throw new InvalidDataException("Robot not found on map");
    }

    private static Position? ExecuteMove(Position position, char move, char[][] map)
    {
        var newPosition = GetNewPosition(position, move);
        if (map[newPosition.Y][newPosition.X] == '#')
        {
            // hit a wall, new position is not valid
            return null;
        }

        if (IsRobotOrBox(newPosition, map))
        {
            // try to move other boxes
            var moveResult = ExecuteMove(newPosition, move, map);
            if (moveResult == null)
            {
                return null;
            }
        }
        
        Swap(newPosition, position, map);

        return newPosition;
    }

    private static void Swap(Position from, Position to, char[][] map)
    {
        (map[from.Y][from.X], map[to.Y][to.X]) = (map[to.Y][to.X], map[from.Y][from.X]);
    }

    private static bool IsRobotOrBox(Position position, char[][] map) => map[position.Y][position.X] == 'O' || map[position.Y][position.X] == '@';

    private static Position GetNewPosition(Position position, char move)
    {
        return move switch
        {
            '<' => position with { X = position.X - 1 },
            '>' => position with { X = position.X + 1 },
            'v' => position with { Y = position.Y + 1 },
            '^' => position with { Y = position.Y - 1 },
            _ => throw new InvalidDataException($"Unrecognized move '${move}'")
        };
    }
}