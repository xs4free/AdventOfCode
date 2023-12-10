namespace MirageMaintenance;

public static class Oasis
{
    public static int PredictAll(IEnumerable<string> lines)
    {
        return lines
            .Select(line => line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList())
            .Select(Predict)
            .Sum();
    }

    private static int Predict(IList<int> line)
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
        
        return Predict(nextLine.ToArray()) + line[^1];
    }
}