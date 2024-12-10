namespace Day07;

public static class Score
{
    public static long Calculate(IEnumerable<Equation> equations)
    {
        return equations.Where(e => e.IsValid()).Select(e => e.Result).Sum();
    }
}