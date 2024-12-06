namespace Day05;

public static class ValidUpdateScore
{
    public static int Score(IEnumerable<IList<int>> validUpdates)
    {
        return validUpdates.Sum(update => update[update.Count / 2]);
    }
}