namespace Day05;

public static class UpdateValidator
{
    public static bool IsValid(List<int> update, Dictionary<int, List<int>> orderingRules)
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

    public static List<int> Fix(List<int> invalidUpdate, Dictionary<int, List<int>> parsedInputOrderingRules)
    {
        var result = new List<int>(invalidUpdate);

        bool swapped;
        do
        {
            swapped = false;
            
            for (var i = 0; i < result.Count; i++)
            {
                var currentPageNumber = result[i];
                if (!parsedInputOrderingRules.TryGetValue(currentPageNumber, out var rightOfCurrentPageNumber))
                {
                    continue;
                }

                var indexOfRightPageNumbers = rightOfCurrentPageNumber.Select(number => result.IndexOf(number)).Where(index => index != -1).ToList();
                if (indexOfRightPageNumbers.Count == 0)
                {
                    continue;
                }
                
                var smallestIndex = indexOfRightPageNumbers.Min();
                if (smallestIndex >= i)
                {
                    continue;
                }
                
                result.RemoveAt(i);
                result.Insert(smallestIndex, currentPageNumber);
                swapped = true;
                break;
            }
        } while (swapped);

        return result;
    }
}