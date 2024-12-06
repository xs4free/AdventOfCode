namespace Day05;

public static class UpdateValidator
{
    public static IEnumerable<IList<int>> GetValidUpdates(ParsedInput input)
    {
        return input.Updates.Where(update => IsUpdateValid(update, input.OrderingRules)).ToList();
    }

    private static bool IsUpdateValid(IList<int> update, Dictionary<int, List<int>> orderingRules)
    {
        var updateIndex = new Dictionary<int, int>();
        for (var i = 0; i < update.Count; i++)
        {
            updateIndex.Add(update[i], i);
        }
        
        for (var i = 0; i < update.Count(); i++)
        {
            if (!orderingRules.TryGetValue(update[i], out var nextValuesAccordingToOrderingRule))
            {
                continue;
            }

            foreach (var nextValue in nextValuesAccordingToOrderingRule)
            {
                if (updateIndex.TryGetValue(nextValue, out var nextValueIndex) 
                    && i >= nextValueIndex)
                {
                    return false;
                }
            }
        }

        return true;
    }
}