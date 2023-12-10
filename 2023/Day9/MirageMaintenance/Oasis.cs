namespace MirageMaintenance;

public static class Oasis
{
    public static int PredictAllValues(IEnumerable<string> lines, PredictDirection direction)
    {
        return lines
            .Select(line => line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList())
            .Select(line => Predict(line, direction))
            .Sum();
    }
    
    private static int Predict(IList<int> line, PredictDirection direction)
    {
        if (line.All(value => value == 0))
        {
            return 0;
        }
        
        List<int> nextLine = new();
        for (var index = 1; index < line.Count; index++)
        {
            nextLine.Add(line[index] - line[index - 1]);
        }

        if (direction == PredictDirection.Next)
        {
            return Predict(nextLine.ToArray(), direction) + line[^1];
        }
        return line[0] - Predict(nextLine.ToArray(), direction);
    }
}

public enum PredictDirection
{
    Next,
    Previous
};
