namespace Day04;

public static class WordFinder
{
    public static int Count(string wordToFind, char[][] input)
    {
        var count = 0;
        
        for (var y = 0; y < input[0].Length; y++)
        {
            for(var x = 0; x < input[0].Length; x++)
            {
                count += CountWordsFromPosition(input, x, y, wordToFind);
            }
        }
        return count;
    }

    private static int CountWordsFromPosition(char[][] input, int x, int y, string wordToFind)
    {
        if (input[y][x] != wordToFind[0])
        {
            return 0;
        }

        return Enum.GetValues(typeof(Direction)).Cast<Direction>()
            .Sum(direction => CheckDirection(input, x, y, wordToFind, direction));
    }

    private static int CheckDirection(char[][] input, int x, int y, string wordToFind, Direction direction)
    {
        var positions = GetPositions(x, y, wordToFind.Length, direction).ToList();
        
        for(var i = 0; i < positions.Count; i++)
        {
            var (currentX,currentY) = positions[i];
            
            // position outside array
            if (currentX < 0 || currentX >= input[0].Length ||
                currentY < 0 || currentY >= input.Length)
            {
                return 0;
            }
            
            // character check at position
            if (input[currentY][currentX] != wordToFind[i])
            {
                return 0;
            }
        }

        return 1;
    }

    private static IEnumerable<(int, int)> GetPositions(int x, int y, int count, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
            case Direction.Down:
            {
                for (int i = 0; i < count; i++)
                {
                    yield return (x, direction == Direction.Up ? y-i : y+i);
                }

                break;
            }
            case Direction.Left:
            case Direction.Right:
            {
                for (int i = 0; i < count; i++)
                {
                    yield return (direction == Direction.Left ? x-i : x+i, y);
                }

                break;
            }
            case Direction.DownRight:
            case Direction.UpLeft:
            {
                for (int i = 0; i < count; i++)
                {
                    yield return (direction == Direction.DownRight ? x+i : x-i, direction == Direction.DownRight ? y+i : y-i);
                }

                break;
            }
            case Direction.DownLeft:
            case Direction.UpRight:
            {
                for (int i = 0; i < count; i++)
                {
                    yield return (direction == Direction.DownLeft ? x-i : x+i, direction == Direction.DownLeft ? y+i : y-i);
                }

                break;
            }
        }
    }
}