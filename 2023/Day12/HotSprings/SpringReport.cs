namespace HotSprings;

public static class SpringReport
{
    public static long SumOfArrangements(IEnumerable<string> input, int unfoldFactor)
    {
        var arrangements = input.Select(line => GetArrangementsCount(line, unfoldFactor));

        return arrangements.Sum();
    }

    private static long GetArrangementsCount(string line, int unfoldFactor)
    {
        var split = line.Split(new[] { ' ', ',' }, StringSplitOptions.TrimEntries| StringSplitOptions.RemoveEmptyEntries);
        
        var foldedInput = split[0];
        var foldedExpectedFailedPipes = split[1..].Select(int.Parse).ToList();

        var count1 = GetArrangements(foldedInput, foldedExpectedFailedPipes).Count;
        var count2 = GetArrangements(foldedInput + '?', foldedExpectedFailedPipes).Count;
        var foldedInput3 = foldedInput.EndsWith('#') ? foldedInput : '?' + foldedInput;  
        var count3 = GetArrangements(foldedInput3, foldedExpectedFailedPipes).Count;
        
        var result = count1;
        for (var i = 1; i < unfoldFactor; i++)
        {
            result *= count3 >= count2 ? count3 : count2;
        }

        return result; //unfoldFactor == 5 ==> count1 * count3 * count3 * count3 * count3;
    }

    private static List<char[]> GetArrangements(string input, List<int> expectedFailedPipes)
    {
        // replace all ? with '.' or '#'
        List<char[]> possibleArrangements = [input.ToCharArray()];
        do
        {
            for (var index = 0; index < possibleArrangements.Count; index++)
            {
                var arrangement = possibleArrangements[index];
                var indexOfQuestionmark = IndexOfQuestionmark(arrangement);
                
                if (indexOfQuestionmark > -1)
                {
                    // remove current arrangement and add arrangements with one less questionmark
                    possibleArrangements.RemoveAt(index);
                    
                    arrangement[indexOfQuestionmark] = '.';
                    if (IsStillPossible(arrangement, expectedFailedPipes))
                    {
                        possibleArrangements.Add((char[])arrangement.Clone());
                    }

                    arrangement[indexOfQuestionmark] = '#';
                    if (IsStillPossible(arrangement, expectedFailedPipes))
                    {
                        possibleArrangements.Add((char[])arrangement.Clone());
                    }

                    break;
                }
            }
        } while (possibleArrangements.Any(arrangement => arrangement.Contains('?')));

        var validArrangements = possibleArrangements.Where(arrangement =>
            GetBrokenPipeGroups(arrangement).SequenceEqual(expectedFailedPipes)).ToList();
        
        return validArrangements;
    }

    private static bool IsStillPossible(char[] arrangement, List<int> expectedFailedPipes)
    {
        var failedPipesSoFar = GetBrokenPipeGroups(arrangement);

        for (var index = 0; index < failedPipesSoFar.Count && index < expectedFailedPipes.Count; index++)
        {
            if (failedPipesSoFar[index] > expectedFailedPipes[index])
            {
                return false;
            }
        }

        return true;
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
        
        var pipesInGroup = 0;
        foreach (var chr in input)
        {
            if (chr == '?')
            {
                break;
            }
            
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