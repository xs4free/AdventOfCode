namespace Day14;

public static class EasterEgg
{
    public static int FindAndPrint(List<Robot> robots, MapSize mapSize)
    {
        // assume we can find the tree by looking for a large number of consecutive robots in a row
        // thanks to large-atom for the number: https://www.reddit.com/r/adventofcode/comments/1hdwdak/comment/m218slt/
        var robotsInRowToFind = (int)Math.Abs(robots.Count / 100.0 * 3.0);

        for (var seconds = 1; ; seconds++)
        {
            // move all robots to the next position
            for (var index = 0; index < robots.Count; index++)
            {
                robots[index] = robots[index] with { Position = RobotSimulator.NextPosition(robots[index].Velocity, mapSize, robots[index].Position) };
            }

            var newPositions = robots.Select(r => r.Position);
            if (ContainsRobotsInRow(newPositions, robotsInRowToFind))
            {
                Print(newPositions, mapSize);
                return seconds;
            }
        }
    }

    private static bool ContainsRobotsInRow(IEnumerable<Position> newPositions, int robotsInRowToFind)
    {
        var rows = newPositions.Distinct().GroupBy(p => p.Y);

        foreach (var row in rows)
        {
            var sorted = row.OrderBy(p => p.X).ToList();
            
            // skip row if not enough robots in row
            if (sorted.Count < robotsInRowToFind)
            {
                continue;
            }

            var continuousCount = 0;
            int? startX = null;
            
            for (var i = 0; i < sorted.Count; i++)
            {
                // break if not enough robots are left to make it to robotsInRowToFind 
                if (sorted.Count - i + continuousCount < robotsInRowToFind)
                {
                    break;
                }
                
                // first robot in a row 
                if (startX == null)
                {
                    startX = sorted[i].X;
                    continuousCount++;
                    continue;
                }
                
                // check if this robot is directly next to the previous robot (x = x + 1)
                if (sorted[i].X == startX + continuousCount)
                {
                    continuousCount++;
                }
                else
                {
                    // start search again from this position
                    startX = sorted[i].X;
                    continuousCount = 1;
                }

                if (continuousCount >= robotsInRowToFind)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static void Print(IEnumerable<Position> robotPositions, MapSize mapSize)
    {
        var map = new bool[mapSize.Height, mapSize.Width];
        foreach (var position in robotPositions)
        {
            map[position.Y, position.X] = true;
        }

        for (var y = 0; y < mapSize.Height; y++)
        {
            for (var x = 0; x < mapSize.Width; x++)
            {
                Console.Write(map[y, x] ? '@' : '.');
            }
            Console.WriteLine();
        }
    }
}