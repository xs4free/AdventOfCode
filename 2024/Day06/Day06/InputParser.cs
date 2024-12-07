namespace Day06;

public static class InputParser
{
    public static char[][] Parse(string[] input)
    {
        return input.Select(line => line.ToCharArray()).ToArray();
    }
}