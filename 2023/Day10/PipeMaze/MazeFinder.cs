namespace PipeMaze;

public static class MazeFinder
{
    public static int StepsToFarthestPoint(IEnumerable<string> lines)
    {
        var maze = lines.Select(line => line.ToCharArray()).ToArray();

        var startPoint = FindMazeStart(maze);

        var steps = WalkRoundMaze(maze, startPoint);

        return steps / 2;
    }

    private static int WalkRoundMaze(char[][] maze, (int x, int y) startPoint)
    {
        var previousPreviousPosition = startPoint;
        var currentPosition = startPoint;
        var steps = 0;

        do
        {
            var previousPosition = currentPosition;
            currentPosition = GetNextPosition(maze, currentPosition, previousPreviousPosition);
            previousPreviousPosition = previousPosition;
            steps++;
            //Console.WriteLine($"Step {steps} ended on (x:{currentPosition.x}, y:{currentPosition.y})");
        } while (currentPosition != startPoint);

        return steps;
    }

    private static (int x, int y) GetNextPosition(char[][] maze, (int x, int y) currentPosition, (int x, int y) previousPosition)
    {
        var nextPositions = GetNextPositions(maze, currentPosition);

        return nextPositions.Except(new []{ previousPosition }).First();
    }

    private static IEnumerable<(int x, int y)> GetNextPositions(char[][] maze, (int x, int y) position)
    {
        List<(int x, int y)> result = [];
        
        switch (maze[position.y][position.x])
        {
            case '|':
                result.Add((position.x, position.y - 1));
                result.Add((position.x, position.y + 1));
                break;
            case '-':
                result.Add((position.x - 1, position.y));
                result.Add((position.x + 1, position.y));
                break;
            case 'L':
                result.Add((position.x, position.y - 1));
                result.Add((position.x + 1, position.y));
                break;
            case 'J':
                result.Add((position.x, position.y - 1));
                result.Add((position.x - 1, position.y));
                break;
            case '7':
                result.Add((position.x, position.y + 1));
                result.Add((position.x - 1, position.y));
                break;
            case 'F':
                result.Add((position.x, position.y + 1));
                result.Add((position.x + 1, position.y));
                break;
            case 'S':
                result.Add(FindPathFromStart(maze, position));
                break;
        }

        return result;
    }

    private static (int x, int y) FindPathFromStart(char[][] maze, (int x, int y) startPosition)
    {
        var above = maze[startPosition.y - 1][startPosition.x];
        if (above is '|' or '7' or 'F')
        {
            return (startPosition.x, startPosition.y - 1);
        }
        
        var below = maze[startPosition.y + 1][startPosition.x];
        
        if (below is '|' or 'L' or 'J')
        {
            return (startPosition.x, startPosition.y + 1);
        }

        var left = maze[startPosition.y][startPosition.x - 1];
        if (left is '-' or 'L' or 'F')
        {
            return (startPosition.x - 1, startPosition.y);
        }
        
        var right = maze[startPosition.y][startPosition.x + 1];
        if (right is '-' or 'J' or '7')
        {
            return (startPosition.x + 1, startPosition.y);
        }

        return (0, 0);
    }

    private static (int x, int y) FindMazeStart(char[][] maze)
    {
        for (var y = 0; y < maze.Length; y++)
        {
            for (var x = 0; x < maze[y].Length; x++)
            {
                if (maze[y][x] == 'S')
                {
                    return (x, y);
                }
            }
        }
        return (0, 0);
    }
}