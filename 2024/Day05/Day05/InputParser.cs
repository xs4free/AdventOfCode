namespace Day05;

public static class InputParser
{
    public static ParsedInput Parse(string[] lines)
    {
        var orderingRules = new Dictionary<int, List<int>>();
        var updates = new List<List<int>>();
        
        foreach (var line in lines)
        {
            if (line.Contains('|'))
            {
                var parts = line.Split("|");
                var leftNumberOfRule = int.Parse(parts[0]);
                var rightNumberOfRule = int.Parse(parts[1]);
                
                if (orderingRules.ContainsKey(leftNumberOfRule))
                {
                    orderingRules[leftNumberOfRule].Add(rightNumberOfRule);
                }
                else
                {
                    orderingRules.Add(leftNumberOfRule, [rightNumberOfRule]);
                }
            }
            else if (line.Contains(','))
            {
                var parts = line.Split(",");
                updates.Add(parts.Select(int.Parse).ToList());
            }
        }
        
        return new ParsedInput(orderingRules, updates);
    }
}