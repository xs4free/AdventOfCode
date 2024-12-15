namespace Day12;

public static class InputParser
{
    public static char[][] Parse(string[] lines)
    {
        return lines.Select(l => l.ToCharArray()).ToArray();
    }
}