namespace ParabolicReflectorDish;

public static class LoadCalculator
{
    public static long Calculate(IEnumerable<string> input)
    {
        var dishMap = input.Select(line => line.ToCharArray()).ToArray();

        dishMap = TiltDishNorth(dishMap);
        
        return CalculateLoad(dishMap);
    }

    private static long CalculateLoad(char[][] dishMap)
    {
        long result = 0;
        
        for (var y = 0; y < dishMap.Length; y++)
        {
            var roundedRocksInline = dishMap[y].Count(pos => pos == 'O');
            var loadFactorLine = dishMap.Length - y;
            result += roundedRocksInline * loadFactorLine;
        }

        return result;
    }

    private static char[][] TiltDishNorth(char[][] dishMap)
    {
        var tilted = new char[dishMap.Length][];
        for (var y = 0; y < dishMap.Length; y++)
        {
            tilted[y] = new char[dishMap[0].Length];
        }

        for (var x = 0; x < dishMap[0].Length; x++)
        {
            var roleToY = 0;
            for (var y = 0; y < dishMap.Length; y++)
            {
                if (dishMap[y][x] == 'O')
                {
                    tilted[roleToY++][x] = 'O';
                }
                else if (dishMap[y][x] == '#')
                {
                    if (y + 1 > dishMap.Length)
                    {
                        break;
                    }

                    tilted[y][x] = '#';
                    roleToY = y + 1;
                }
                else
                {
                    tilted[y][x] = '.';
                }
            }
        }
        
        return tilted;
    }
}