namespace Boatrace;

internal static class RaceReader
{
    /// <summary>
    /// Time:      7  15   30
    /// Distance:  9  40  200                
    /// </summary>
    public static IEnumerable<Race> GetRaces(IEnumerable<string> input)
    {
        long[]? times = null, distances = null;

        foreach(var line in input)
        {
            var split = line.Split(new[] { ":", " "}, StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);

            if (split[0] == "Time")
            {
                times = split.Skip(1).Select(long.Parse).ToArray();
            }

            if (split[0] == "Distance")
            {
                distances = split.Skip(1).Select(long.Parse).ToArray();
            }
        }

        if (times == null || distances == null)
        {
            yield break;
        }
            
        for (int index = 0; index < times.Length; index++)
        {
            yield return new Race(times[index], distances[index]);
        }
    }

    public static Race? GetCombinedRaces(IEnumerable<string> input)
    {
        long? time = null, distance = null;
        foreach(var line in input)
        {
            var split = line.Split( ":", StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);

            if (split[0] == "Time")
            {
                time = long.Parse(split[1].Replace(" ", string.Empty));
            }

            if (split[0] == "Distance")
            {
                distance = long.Parse(split[1].Replace(" ", string.Empty));
            }
        }

        if (time != null && distance != null)
        {
            return new Race(time.Value, distance.Value);
        }
        
        return null;
    }
    
}