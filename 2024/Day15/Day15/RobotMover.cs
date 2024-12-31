namespace Day15;

public static class RobotMover
{
    public static char[][] Move(char[][] map, char[] moves)
    {
        var result  = (char[][])map.Clone();
        var robotPosition = FindRobot(result);

        foreach (var move in moves)
        {
            if (CanMove(robotPosition, move, result))
            {
                robotPosition = Move(robotPosition, move, result);
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

    private static bool CanMove(Position position, char move, char[][] map)
    {
        var newPosition = GetNewPosition(position, move);
        
        if (IsOpenSpace(newPosition, map))
        {
            return true;
        }
        
        if (IsSmallBox(newPosition, map))
        {
            return CanMove(newPosition, move, map);
        }

        if (IsLargeBox(newPosition, map))
        {
            Position boxLeft = map[newPosition.Y][newPosition.X] == '[' ? newPosition : newPosition with { X = newPosition.X - 1 };
            Position boxRight = map[newPosition.Y][newPosition.X] == '[' ? newPosition with { X = newPosition.X + 1 } : newPosition;

            if (move == '<')
            {
                return CanMove(boxLeft, move, map);
            }
            if (move == '>')
            {
                return CanMove(boxRight, move, map);
            }
            return CanMove(boxLeft, move, map) && CanMove(boxRight, move, map);
        }
        
        return false;
    }
    
    private static Position Move(Position position, char move, char[][] map)
    {
        var newPositions = GetNewPositions(position, move, map).ToList();

        foreach (var newPosition in newPositions)
        {
            if (!IsOpenSpace(newPosition, map))
            {
                Move(newPosition, move, map);
            }
        }

        if (IsRobot(position, map) || IsSmallBox(position, map))
        {
            var newPosition = GetNewPosition(position, move);
            Swap(newPosition, position, map);
            return newPosition;
        }

        var positionBoxLeft = map[position.Y][position.X] == '[' ? position : position with { X = position.X - 1 };
        var positionBoxRight = map[position.Y][position.X] == '[' ? position with { X = position.X + 1 } : position;
        var newPositionLeft = GetNewPosition(positionBoxLeft, move);
        var newPositionRight = GetNewPosition(positionBoxRight, move);

        if (move is '<' or '^' or 'v')
        {
            Swap(newPositionLeft, positionBoxLeft, map);
            Swap(newPositionRight, positionBoxRight, map);
        }
        else
        {
            Swap(newPositionRight, positionBoxRight, map);
            Swap(newPositionLeft, positionBoxLeft, map);
        }

        return position == positionBoxLeft ? newPositionLeft : newPositionRight;
    }


    private static void Swap(Position from, Position to, char[][] map)
    {
        (map[from.Y][from.X], map[to.Y][to.X]) = (map[to.Y][to.X], map[from.Y][from.X]);
    }

    private static bool IsOpenSpace(Position newPosition, char[][] map) => map[newPosition.Y][newPosition.X] == '.';
    private static bool IsRobot(Position position, char[][] map) => map[position.Y][position.X] is '@';
    private static bool IsSmallBox(Position position, char[][] map) => map[position.Y][position.X] is 'O';
    private static bool IsLargeBox(Position position, char[][] map) => map[position.Y][position.X] is '[' or ']';


    private static IEnumerable<Position> GetNewPositions(Position position, char move, char[][] map)
    {
        if (IsSmallBox(position, map) || IsRobot(position, map))
        {
            yield return GetNewPosition(position, move);
        }

        if (IsLargeBox(position, map))
        {
            var positionBoxLeft = map[position.Y][position.X] == '[' ? position : position with { X = position.X - 1 };
            var positionBoxRight = map[position.Y][position.X] == '[' ? position with { X = position.X + 1 } : position;

            if (move == '>')
            {
                yield return GetNewPosition(positionBoxRight, move);
            }
            else if (move == '<')
            {
                yield return GetNewPosition(positionBoxLeft, move);
            }
            else
            {
                yield return GetNewPosition(positionBoxLeft, move);
                yield return GetNewPosition(positionBoxRight, move);
            }
        }
    }

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