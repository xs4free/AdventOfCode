namespace Day15;

public static class GpsScorer
{
    public static long Score(char[][] map)
    {
        long result = 0;
        
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == 'O' || map[y][x] == '[')
                {
                    result += 100 * y + x;
                }
            }
        }

        return result;
    }
}