namespace ParabolicReflectorDish;

public static class LoadCalculator
{
    public static long Calculate(IEnumerable<string> input)
    {
        var dishMap = input.Select(line => line.ToCharArray()).ToArray();

        dishMap = TiltDish(dishMap, TiltDirection.North);
        
        return CalculateLoad(dishMap);
    }

    private static int CalculateLoad(char[][] dishMap)
    {
        var result = 0;
        
        for (var y = 0; y < dishMap.Length; y++)
        {
            var roundedRocksInline = dishMap[y].Count(pos => pos == 'O');
            var loadFactorLine = dishMap.Length - y;
            result += roundedRocksInline * loadFactorLine;
        }

        return result;
    }

    public static char[][] TiltDish(char[][] dishMap, TiltDirection direction)
    {
        var tilted = new char[dishMap.Length][];
        for (var y = 0; y < dishMap.Length; y++)
        {
            tilted[y] = new char[dishMap[0].Length];
        }

        switch (direction)
        {
            case TiltDirection.North:
            case TiltDirection.South:
                TiltDishVertical(dishMap, tilted, direction);
                break;
            case TiltDirection.East:
            case TiltDirection.West:
                TiltDishHorizontal(dishMap, tilted, direction);
                break;
        }
        
        return tilted;
    }

    private static void TiltDishVertical(char[][] dishMap, char[][] tilted, TiltDirection direction)
    {
        for (var x = 0; x < dishMap[0].Length; x++)
        {
            var roleToY = direction == TiltDirection.North ? 0 : dishMap.Length - 1;
            var step = direction == TiltDirection.North ? 1 : -1;
           
            for (var index = 0; index < dishMap.Length; index++)
            {
                var y = direction == TiltDirection.North ? index : dishMap.Length - 1 - index;
                
                if (dishMap[y][x] == 'O')
                {
                    tilted[roleToY][x] = 'O';
                    if (roleToY != y)
                    {
                        tilted[y][x] = '.';
                    }
                    roleToY += step;
                }
                else if (dishMap[y][x] == '#')
                {
                    tilted[y][x] = '#';
                    roleToY = y + step;
                }
                else
                {
                    tilted[y][x] = '.';
                }
            }
        }
    }

    private static void TiltDishHorizontal(char[][] dishMap, char[][] tilted, TiltDirection direction)
    {
        for (var y = 0; y < dishMap.Length; y++)
        {
            var roleToX = direction == TiltDirection.West ? 0 : dishMap[0].Length - 1;
            var step = direction == TiltDirection.West ? 1 : -1;
            
            for (var index = 0; index < dishMap[0].Length; index++)
            {
                var x = direction == TiltDirection.West ? index : dishMap[0].Length - 1 - index;
                
                if (dishMap[y][x] == 'O')
                {
                    tilted[y][roleToX] = 'O';
                    if (roleToX != x)
                    {
                        tilted[y][x] = '.';
                    }
                    roleToX += step;
                }
                else if (dishMap[y][x] == '#')
                {
                    tilted[y][x] = '#';
                    roleToX = x + step;
                }
                else
                {
                    tilted[y][x] = '.';
                }
            }
        }
    }
 
    public static long CalculateWithCycles(IEnumerable<string> input, int cycles)
    {
        var dishMap = input.Select(line => line.ToCharArray()).ToArray();

        var (startIndex, loopSize) = FindCycleLoop(dishMap);

        var index = (cycles - startIndex) % loopSize;
        var lastDish = DishList[startIndex + index];
        
        return lastDish.load;
    }

    private static readonly List<(char[][] dish, int load)> DishList = [];
    private static readonly Dictionary<string, int> DishCache = new();

    private static (int startIndex, int loopSize) FindCycleLoop(char[][] dish)
    {
        while(true)
        {
            var hash = HashDish(dish);
            DishList.Add((dish, CalculateLoad(dish)));
            if (!DishCache.TryAdd(hash, DishList.Count - 1))
            {
                var loopStartIndex = DishCache[hash];
                var loopSize = DishList.Count - loopStartIndex - 1;
                return (loopStartIndex, loopSize);
            }
            
            dish = CycleDish(dish, 1);
        }
    }

    public static char[][] CycleDish(char[][] dish, long times)
    {
        for (var index = 0; index < times; index++)
        {
            dish = TiltDish(dish, TiltDirection.North);
            dish = TiltDish(dish, TiltDirection.West);
            dish = TiltDish(dish, TiltDirection.South);
            dish = TiltDish(dish, TiltDirection.East);
        }

        return dish;
    }
    
    private static string HashDish(char[][] dish)
    {
        return new string(dish.SelectMany(line => line).ToArray());
    }
}