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

        var unfoldedInput = string.Empty;
        var unfoldedExpectedFailedPipes = new List<int>();
        
        for (var index = 0; index < unfoldFactor; index++)
        {
            unfoldedInput += foldedInput;
            if (unfoldFactor > 0 && index < unfoldFactor - 1)
            {
                unfoldedInput += '?';
            }
            unfoldedExpectedFailedPipes.AddRange(foldedExpectedFailedPipes);
        }

        return Count(unfoldedInput, unfoldedExpectedFailedPipes);
    }

    private static readonly Dictionary<string, long> Cache = new();
    private static long Count(string input, List<int> expectedFailedPipes)
    {
        if (string.IsNullOrEmpty(input))
        {
            // if the input is empty but we are stil expecting failed pipes, this is not a valid arrangement
            return expectedFailedPipes.Count == 0 ? 1 : 0; 
        }

        if (expectedFailedPipes.Count == 0)
        {
            // if there is still a broken pipe in the input, but non is expected this is not a valid arrangement
            return input.Contains('#') ? 0 : 1; 
        }

        var neededSeperators = expectedFailedPipes.Count > 0 ? expectedFailedPipes.Count - 1 : expectedFailedPipes.Count;
        if (expectedFailedPipes.Sum() + neededSeperators > input.Length)
        {
            // if the expected number of failed pipes is larger than the remaining input this is not a valid arrangement
            return 0;
        }

        var key = $"{input} - {string.Join(',', expectedFailedPipes)}";
        if (Cache.TryGetValue(key, out var cachedValue))
        {
            return cachedValue;
        }

        long result = 0;
        
        // first character is not a pipe (or can be treated like a non-pipe), so no extra options except all next characters
        if (input[0] is '.' or '?')
        {
            result += Count(input[1..], expectedFailedPipes);
        }

        if (input[0] is '#' or '?')
        {
            var expectedCountFailedPipes = expectedFailedPipes[0];

            if (
                // does the expected number of failed pipes even fit in the remaining input?
                expectedCountFailedPipes <= input.Length
                // is it possible to place required pipes in the next set of positions
                && !input[..expectedCountFailedPipes].Contains('.')
                // first character after expected failed pipes shouldn't be another failed pipe
                && (expectedCountFailedPipes == input.Length || input[expectedCountFailedPipes] != '#')) 
            {
                // skip past the expected first number of pipes in the input and try to fit the rest of the expected failed pipes
                var index = input.Length > expectedCountFailedPipes+1 ? expectedCountFailedPipes+1 : expectedCountFailedPipes;  
                result += Count(input[index..], expectedFailedPipes[1..]);
            }
        }
        
        Cache.Add(key, result);
        return result;
    }
}