﻿namespace Boatrace;

internal static class RaceReader
{
    /// <summary>
    /// Time:      7  15   30
    /// Distance:  9  40  200                
    /// </summary>
    public static IEnumerable<Race> GetRaces(IEnumerable<string> input)
    {
        int[]? times = null, distances = null;

        foreach(var line in input)
        {
            var split = line.Split(new[] { ":", " "}, StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);

            if (split[0] == "Time")
            {
                times = split.Skip(1).Select(int.Parse).ToArray();
            }

            if (split[0] == "Distance")
            {
                distances = split.Skip(1).Select(int.Parse).ToArray();
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
    
}