using System.Diagnostics;

namespace HotSprings;

public static class SpringReport
{
    public static int SumOfArrangements(IEnumerable<string> input)
    {
        var arrangements = input.Select(GetArrangementsCount);

        return arrangements.Sum();
    }

    private static int GetArrangementsCount(string line)
    {
        var split = line.Split(new[] { ' ', ',' }, StringSplitOptions.TrimEntries| StringSplitOptions.RemoveEmptyEntries);
        
        var input = split[0];

        var expectedFailedPipes = split[1..].Select(int.Parse).ToList();

        var arrangements = GetArrangements(input, expectedFailedPipes);

        return arrangements.Count;
    }

    private static List<char[]> GetArrangements(string input, List<int> expectedFailedPipes)
    {
        // replace all ? with '.' or '#'
        List<char[]> possibleArrangements = [input.ToCharArray()];
        do
        {
            var count = possibleArrangements.Count;
            for (var index = 0; index < count; index++)
            {
                var arrangement = possibleArrangements[index];
                var indexOfQuestionmark = IndexOfQuestionmark(arrangement);
                
                if (indexOfQuestionmark > -1)
                {
                    // replace questionmark with '.' in array in list
                    arrangement[indexOfQuestionmark] = '.';

                    // replace questionmark with '#' and add new array to list
                    arrangement = (char[])arrangement.Clone();
                    arrangement[indexOfQuestionmark] = '#';
                    possibleArrangements.Add(arrangement);
                }
            }
        } while (possibleArrangements.Any(arrangement => arrangement.Contains('?')));

        var validArrangements = possibleArrangements.Where(arrangement =>
            GetBrokenPipeGroups(arrangement).SequenceEqual(expectedFailedPipes)).ToList();
        
        return validArrangements;
    }

    private static int IndexOfQuestionmark(char[] arrangement)
    {
        for (var index = 0; index < arrangement.Length; index++)
        {
            if (arrangement[index] == '?')
            {
                return index;
            }
        }

        return -1;
    }

    public static List<int> GetBrokenPipeGroups(char[] input)
    {
        List<int> result = [];
        
        Debug.Assert(input.All(c => c != '?'));

        var pipesInGroup = 0;
        foreach (var chr in input)
        {
            if (chr == '#')
            {
                pipesInGroup++;
            }
            else if (pipesInGroup > 0)
            {
                result.Add(pipesInGroup);
                pipesInGroup = 0;
            }
        }
        
        if (pipesInGroup > 0)
        {
            result.Add(pipesInGroup);
        }        

        return result;
    }
}