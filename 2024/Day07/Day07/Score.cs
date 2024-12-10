namespace Day07;

public static class Score
{
    public static long Calculate(IEnumerable<Equation> equations, List<Operator> validOperators)
    {
        return equations.Where(e => e.IsValid(validOperators)).Select(e => e.Result).Sum();
    }
}