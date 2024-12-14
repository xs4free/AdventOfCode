namespace Day10;

public static class InputParser
{
    public static int[][] Parse(string[] lines)
    {
        return lines.Select(line => line.Select(c => c - '0').ToArray()).ToArray();
    }
}